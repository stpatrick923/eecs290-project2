/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

// In order for this script to work, the object its applied to must have a Rigidbody and AudioSource component.
// This tells Unity to always have the components when this script is attached.
[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]

public class Spaceship : MonoBehaviour {

    public GameObject Lerpz;

    //What is our forward direction?  Our spaceship moves in the positive y direction.
    public Vector3 forwardDirection = new Vector3(0.0f, 1.0f, 0.0f);

    // Below we create two helper classes, MovementSettings and SpecialEffects
    // Although the helper classes are not necessary, it makes for nice clean code and usage.

    [System.Serializable]
    public class MovementSettings {
        public MovementSettings ShallowCopy() { return (MovementSettings)this.MemberwiseClone(); }

	    // What is the maximum speed of this movement?
	    public float maxSpeed;
	
	    // What's the acceleration in the positive and negative directions associated with this movement?
	    public float positiveAcceleration;
	    public float negativeAcceleration;
	
	    // How much drag should we apply when there isn't input for this movement?
	    public float dragWhileCoasting;
	
	    // How much drag should we apply to slow down the movement for speeds above maxSpeed?
	    public float dragWhileBeyondMaxSpeed;
	
	    // When neither of the above drag factors are in play, how much drag should there normally be?  (Usually very small.)
	    public float dragWhileAcceleratingNormally;
	
	    // This function determines which drag variable to use and returns one.
	    public float ComputeDrag (float input, Vector3 velocity) {
		    //Is the input not zero (the 0.01 allows for some error since we're working with floats and they aren't completely precise)
		    if (Mathf.Abs (input) > 0.01) {
			    // Are we greater or less than our max speed? Then return the appropriate drag.
			    if (velocity.magnitude > maxSpeed)
				    return dragWhileBeyondMaxSpeed;
			    else
				    return dragWhileAcceleratingNormally;
		    } else
			    //If the input is zero, use dragWhileCoasting
			    return dragWhileCoasting;
	    }
    }

    [System.Serializable]
    public class SpecialEffects {
	    // There are four possible special effects that can be assigned.
	    public GameObject positiveThrustEffect;
	    public GameObject negativeThrustEffect;
	    public GameObject positiveTurnEffect;
	    public GameObject negativeTurnEffect;
	
	    // How loud should collision sounds be? This is used in the OnCollisionEnter () function.
	    public float collisionVolume = 0.01f;
    }

    // We create two instances using our MovementSettings helper class.
    // One will be for translational (position) movement, the other for rotational.
    public MovementSettings positionalMovement;
    public MovementSettings rotationalMovement;

    // We create an instance using our SpecialEffects helper class.
    public SpecialEffects specialEffects;

    // Can the user control the spaceship currently?  This will be toggled by another script that also toggles what the camera should track.
    public bool canControl = true;

    //added for C#
    private float thrust = 0.0f;
    private float turn = 0.0f;

    //FixedUpdate () is advantageous over Update () for working with rigidbody physics.
    void FixedUpdate () {
        if (GameData.Instance.Paused)
            return;
	    // Retrieve input.  Note the use of GetAxisRaw (), which in this case helps responsiveness of the controls.
	    // GetAxisRaw () bypasses Unity's builtin control smoothing.
	    thrust = Input.GetAxisRaw ("Vertical");
	    turn = Input.GetAxisRaw ("Horizontal");
	
	    if (!canControl) {
		    thrust = 0.0f;
		    turn = 0.0f;
	    }
	
	    //Use the MovementSettings class to determine which drag constant should be used for the positional movement.
	    //Remember the MovementSettings class is a helper class we defined ourselves. See the top of this script.
	    rigidbody.drag = positionalMovement.ComputeDrag (thrust, rigidbody.velocity);

	    //Then determine which drag constant should be used for the angular movement.
	    rigidbody.angularDrag = rotationalMovement.ComputeDrag (turn, rigidbody.angularVelocity);
	
	    //Determines which direction the positional and rotational motion is occurring, and then modifies thrust/turn with the given accelerations. 
	    //If you are not familiar with the ?: conditional, it is basically shorthand for an "if..else" statement pair.  See http://www.javascriptkit.com/jsref/conditionals.shtml
	    thrust *= (thrust > 0.0) ? positionalMovement.positiveAcceleration : positionalMovement.negativeAcceleration;
	    turn *= (turn > 0.0) ? rotationalMovement.positiveAcceleration : rotationalMovement.negativeAcceleration;
	
	    // Add torque and force to the rigidbody.  Torque will rotate the body and force will move it.
	    // Always modify your forces by Time.deltaTime in FixedUpdate (), so if you ever need to change your Time.fixedTime setting,
	    // your setup won't break.
 	    rigidbody.AddRelativeTorque (new Vector3(0.0f, 0.0f, -1.0f) * turn * Time.deltaTime, ForceMode.VelocityChange);
	    rigidbody.AddRelativeForce (forwardDirection * thrust * Time.deltaTime, ForceMode.VelocityChange);
    }

    // This function allows us to SendMessage to an object to set whether or not the player can control it
    public void SetControllable (bool controllable) {
	    canControl = controllable;
    }

    // The Update () function only serves to provide special effects in this case.
    void Update () {
        if (GameData.Instance.Paused)
            return;

        if (Input.GetButton("Fire2") && canControl)
            ExitSpaceship();

	    //Collecting appropriate input.
	    thrust = Input.GetAxisRaw ("Vertical");
	    turn = Input.GetAxisRaw ("Horizontal");
	
	    if (!canControl) {
		    thrust = 0.0f;
		    turn = 0.0f;
	    }
	
	    // If the thrust effect slots aren't null in the inspector, send a message.
	    // The message will be received by the component SpecialEffectHandler
	    // If the boolean statement is true, (e.g. (thrust > 0.01)) then the special effects will be enabled.
	    if (specialEffects.positiveThrustEffect)
		    specialEffects.positiveThrustEffect.SendMessage ("SetSpecialEffectActive", (thrust > 0.01));

	    if (specialEffects.negativeThrustEffect)
		    specialEffects.negativeThrustEffect.SendMessage ("SetSpecialEffectActive", (thrust < -0.01));

	    if (specialEffects.positiveTurnEffect)
		    specialEffects.positiveTurnEffect.SendMessage ("SetSpecialEffectActive", (turn > 0.01));

	    if (specialEffects.negativeTurnEffect)
		    specialEffects.negativeTurnEffect.SendMessage ("SetSpecialEffectActive", (turn < -0.01));	
    }

    // The OnCollisionEnter () function only serves to provide special effects in this case.
    void OnCollisionEnter (Collision collision) {
	    // Get the component "CollisionSoundEffect" of the object we collided with.
	    // The platforms in this tutorial have a CollisionSoundEffect component.
	    CollisionSoundEffect collisionSoundEffect = (CollisionSoundEffect) collision.gameObject.GetComponent ("CollisionSoundEffect");

	    // If collisionSoundEffect isn't null, get the audio clip, set the volume, and play.
	    if (collisionSoundEffect) {
		    audio.clip = collisionSoundEffect.audioClip;
		    // By multiplying by collision.relativeVelocity.sqrMagnitude, the sound will be louder for faster impacts.
		    audio.volume = collisionSoundEffect.volumeModifier * collision.relativeVelocity.sqrMagnitude * specialEffects.collisionVolume;
		    audio.Play ();		
	    }
    }

    // The Reset () function is called by Unity when you first add a script, and when you choose Reset on the
    // gear popup menu for the script.
    void Reset () {
	    // Set some nice default values for our MovementSettings.
	    // Of course, it is always best to tweak these for your specific game.
	    positionalMovement.maxSpeed = 3.0f;
	    positionalMovement.dragWhileCoasting = 3.0f;
	    positionalMovement.dragWhileBeyondMaxSpeed = 4.0f;
	    positionalMovement.dragWhileAcceleratingNormally = 0.01f;
	    positionalMovement.positiveAcceleration = 50.0f;
	
	    // By default, we don't have reverse thrusters.
	    positionalMovement.negativeAcceleration = 0.0f;
	
	    rotationalMovement.maxSpeed = 2.0f;
	    rotationalMovement.dragWhileCoasting = 32.0f;
	    rotationalMovement.dragWhileBeyondMaxSpeed = 16.0f;
	    rotationalMovement.dragWhileAcceleratingNormally = 0.1f;

	    // For rotation, acceleration is usually the same in both directions.
	    // It could make for interesting unique gameplay if it were significantly
	    // different, however!
	    rotationalMovement.positiveAcceleration = 50.0f;
	    rotationalMovement.negativeAcceleration = 50.0f;
    }

    void EnterSpaceship()
    {
        DeactivateLerpz();
    }

    void ExitSpaceship()
    {
        ActivateLerpz();

        if (turn < 0)
        {
            Lerpz.transform.position = new Vector3(transform.position.x - 2 * transform.localScale.x, transform.position.y, 0);
        }
        else
            Lerpz.transform.position = new Vector3(transform.position.x + 2 * transform.localScale.x, transform.position.y, 0);
    }

    void ActivateLerpz()
    {
        SetControllable(false);
        Lerpz.gameObject.SetActive(true);
        Lerpz.SendMessage("SetControllable", true, SendMessageOptions.DontRequireReceiver);
        CameraScrolling camera = (CameraScrolling)Camera.main.GetComponent("CameraScrolling");
        camera.SetTarget(Lerpz.transform);
    }

    void DeactivateLerpz()
    {
        SetControllable(true);
        Lerpz.gameObject.SendMessage("SetControllable", false, SendMessageOptions.DontRequireReceiver);
        CameraScrolling camera = (CameraScrolling)Camera.main.GetComponent("CameraScrolling");
        camera.SetTarget(transform);
        Lerpz.gameObject.SetActive(false);
    }
}
