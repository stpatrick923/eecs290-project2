/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Foot Effects")
            transform.parent.gameObject.AddComponent<Rigidbody>();
    }
}
