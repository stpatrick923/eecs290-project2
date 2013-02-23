/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class CollisionParticleEffect : MonoBehaviour {

    // Small script to hold a reference to a prefab used for when the player hits me.

    // This script is attached to game object making up your level. 
    // The "Foot" script (which is attached to the player) looks for this script on whatever it touches.
    // If it finds it, then it will spawn one of these

    public GameObject effect;

}
