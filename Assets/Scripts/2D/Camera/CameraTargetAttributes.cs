/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class CameraTargetAttributes : MonoBehaviour
{

    // This script goes on any GameObject in your scene that you will track with the camera.
    // It'll help customize the camera tracking to your specific object to polish your game.

    // See the GetGoalPosition () function in CameraScrolling.js for an explanation of these variables.
    public float heightOffset = 0.0f;
    public float distanceModifier = 1.0f;
    public float velocityLookAhead = 0.15f;
    public Vector2 maxLookAhead = new Vector2(3.0f, 3.0f);
}
