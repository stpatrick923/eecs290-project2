/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class RotatingPlatform : MonoBehaviour {

    public float RotationSpeed;
	
	// Update is called once per frame
	void Update () 
    {
        if (GameData.Instance.Paused)
            return;
        transform.RotateAroundLocal(Vector3.back, RotationSpeed * Time.deltaTime);   
	}
}
