/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using UnityEditor;
using System.Collections;

public class TwoDHelper : MonoBehaviour 
{
    // Make a menu item that move stuff on to the 2D plane
    [MenuItem ("2D/Move Onto 2D Plane ^2")]
    static void MoveOnto2DPlane () {
	    // Go over all transforms in Unity Editor's selection
	    foreach (Transform transform in Selection.transforms) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	    }
    }

    // This function is called to determine if the function can be executed.
    [MenuItem ("2D/Move Onto 2D Plane ^2", true)]
    static bool ValidateMoveOnto2DPlane () {
	    // we only return true if we have a transform in the selection.
	    return (Selection.activeTransform != null);
    }

    [MenuItem ("2D/Make Selection 2D Rigidbody")]
    static void MakeSelection2DRigidbody () {
	    // Start by moving all game objects onto the playing field plane
	    MoveOnto2DPlane ();
	
	    // Go over all transforms in selection.
	    foreach (Transform transform in Selection.transforms) {
		    // Make sure that the transform has a rigidbody.
		    Rigidbody rigidbody = (Rigidbody)transform.GetComponent ("Rigidbody");
		    if (!rigidbody)
			    transform.gameObject.AddComponent ("Rigidbody");
		
		    // Make sure that here is also a ConfigurableJoint
		    ConfigurableJoint configurableJoint = (ConfigurableJoint)transform.GetComponent ("ConfigurableJoint");	
		    if (!configurableJoint)
			    configurableJoint = transform.gameObject.AddComponent ("ConfigurableJoint") as ConfigurableJoint;
		
		    // Make the joint force the object to only move in the XY plane and only rotate around Z
		    configurableJoint.xMotion = ConfigurableJointMotion.Free;
		    configurableJoint.yMotion = ConfigurableJointMotion.Free;
		    configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		    configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
		    configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
		    configurableJoint.angularZMotion = ConfigurableJointMotion.Free;

            transform.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
	    }	
    }

    // We can only execute the above menu command if there is a transform in the selection
    [MenuItem ("2D/Make Selection 2D Rigidbody", true)]
    static bool ValidateMakeSelection2DRigidbody () {
	    return (Selection.activeTransform != null);
    }

    // Make a menu item that move stuff on to the 2D plane
    [MenuItem("2D/half size platform")]
    static void HalfSizePlatform()
    {
        // Go over all transforms in Unity Editor's selection
        foreach (Transform transform in Selection.transforms)
        {
            transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y, transform.localScale.z);
        }
    }

    // This function is called to determine if the function can be executed.
    [MenuItem("2D/half size platform", true)]
    static bool ValidateHalfSizePlatform()
    {
        // we only return true if we have a transform in the selection.
        if (Selection.activeTransform != null)
        {
            foreach (Transform transform in Selection.transforms)
                if (transform.gameObject.name != "Platform - Level")
                    return false;
            return true;
        }
        return false;
    }

    // % = strg, # = shift, _x = x, & = alt
    [MenuItem("2D/Move Platform Down &s")]
    static void MovePlatformDown()
    {
        foreach (Transform transform in Selection.transforms)
        {
            transform.position = new Vector3(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y) - 0.5f, 0);
        }
    }

    [MenuItem("2D/Move Platform Down &s", true)]
    static bool ValidateMovePlatformDown()
    {
        return (Selection.activeTransform != null);
    }


    [MenuItem("2D/Move Platform Up &w")]
    static void MovePlatformUp()
    {
        foreach (Transform transform in Selection.transforms)
        {
            transform.position = new Vector3(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y) + 1f, 0);
        }
    }

    [MenuItem("2D/Move Platform Up &w", true)]
    static bool ValidateMovePlatformUp()
    {
        return (Selection.activeTransform != null);
    }

    [MenuItem("2D/Move Platform Right &d")]
    static void MovePlatformRight()
    {
        foreach (Transform transform in Selection.transforms)
        {
            transform.position = new Vector3(Mathf.FloorToInt(transform.position.x) + 1f, Mathf.FloorToInt(transform.position.y), 0);
        }
    }

    [MenuItem("2D/Move Platform Right &d", true)]
    static bool ValidateMovePlatformRight()
    {
        return (Selection.activeTransform != null);
    }

    [MenuItem("2D/Move Platform Left &a")]
    static void MovePlatformLeft()
    {
        foreach (Transform transform in Selection.transforms)
        {
            transform.position = new Vector3(Mathf.FloorToInt(transform.position.x) - 0.5f, Mathf.FloorToInt(transform.position.y), 0);
        }
    }

    [MenuItem("2D/Move Platform Left &a", true)]
    static bool ValidateMovePlatformLeft()
    {
        return (Selection.activeTransform != null);
    }
}
