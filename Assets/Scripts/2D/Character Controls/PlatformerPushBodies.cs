/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class PlatformerPushBodies : MonoBehaviour {

    // Script added to a player for it to be able to push rigidbodies around.

    // How hard the player can push
    public float pushPower = 0.5f;

    // Which layers the player can push
    // This is useful to make unpushable rigidbodies
    public LayerMask pushLayers = -1;

    // pointer to the player so we can get values from it quickly
    private PlatformerController controller;

    void Start () {
	    controller = (PlatformerController)GetComponent ("PlatformerController");
    }

    void OnControllerColliderHit (ControllerColliderHit hit) {
        if (hit.gameObject.name == "Spaceship")
        {
            hit.gameObject.SendMessage("EnterSpaceship", SendMessageOptions.DontRequireReceiver);
            return;
        }

	    Rigidbody body = hit.collider.attachedRigidbody;
	    // no rigidbody
	    if (body == null || body.isKinematic)
		    return;

	    // Only push rigidbodies in the right layers
	    int bodyLayerMask = 1 << body.gameObject.layer;
	    if ((bodyLayerMask & pushLayers.value) == 0)
		    return;
		
	    // We dont want to push objects below us
	    if (hit.moveDirection.y < -0.3) 
		    return;
	
	    // Calculate push direction from move direction, we only push objects to the sides
	    // never up and down
	    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
	
	    // push with move speed but never more than walkspeed
	    body.velocity = pushDir * pushPower * Mathf.Min (controller.GetSpeed (), controller.movement.walkSpeed);
    }
}
