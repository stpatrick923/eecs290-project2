/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class FallingPlatformVertical : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameObject.AddComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
            collider.enabled = false;
        }
    }
}
