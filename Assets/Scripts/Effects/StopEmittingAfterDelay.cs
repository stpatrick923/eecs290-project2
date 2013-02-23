/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class StopEmittingAfterDelay : MonoBehaviour {

    // Small helper script to turn off a particle emitter after a given delay

    public float delay = 0.1f;	// The pause to take. 

    void Start()
    {
        StopEmitting();
    }
    IEnumerator StopEmitting()
    {
        // We start out by waiting for a little while
        yield return new WaitForSeconds(delay);

        // Then we turn of the particle emitter
        particleEmitter.emit = false;
    }
}
