/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

// This line tells Unity to nicely place this script in a submenu of the Component menu.
[AddComponentMenu("2D Platformer/Moving Platform/Moving Platform Effects")]

public class MovingPlatformEffects : MonoBehaviour 
{
    // We will turn on our special effects when the platform is raising, but if it is moving side
    // to side, how fast does it have to be moving to cause our special effects to turn on?
    public float horizontalSpeedToEnableEmitters = 1.0f;

    // A true/false (boolean) variable to keep track of whether or not our special effects are
    // currently turned on.
    private bool areEmittersOn;

    //  We are going to use these later to calculate the current velocity.
    private Vector3 oldPosition;
    private Vector3 currentVelocity;

    void Start() {
	    // Grabs the initial position of the platform.
	    oldPosition = transform.position;
    }

    void Update() {
 	    // Remember if our emitters were on, then we'll see if they are currently on.
	    bool wereEmittersOn = areEmittersOn;
	
	    // The emitters are on if the vertical (y) velocity is greater than 0 (positive), or if the
	    // horizontal velocity in either direction (positive or negative speed) is greater than
	    // our horizontalSpeedToEnableEmitters threshold.
	    areEmittersOn = (currentVelocity.y > 0) || (Mathf.Abs(currentVelocity.x) > horizontalSpeedToEnableEmitters);
	
	    // We only have to update the particle emitters if the state of them has changed.
	    // This saves needless computation.
	    if (wereEmittersOn != areEmittersOn) {
		    // Get every child ParticleEmitter in the moving platform.
		    foreach (ParticleEmitter emitter in GetComponentsInChildren<ParticleEmitter>()) {
			    //Simply set them to emit or not emit depending on the value of areEmittersOn
			    emitter.emit = areEmittersOn;
		    }
	    }
    }


    void LateUpdate () {
	    currentVelocity = transform.position - oldPosition;
	    oldPosition = transform.position;
    }
}
