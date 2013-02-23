/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour
{

    public GameObject targetA;
    public GameObject targetB;

    public float speed = 0.1f;
    public bool activeMovement = true;

    void FixedUpdate()
    {
        if (!activeMovement) return;
        float weight = Mathf.Cos(Time.time * speed * 2f * Mathf.PI) * 0.5f + 0.5f;
        transform.position = targetA.transform.position * weight
                            + targetB.transform.position * (1 - weight);
    }
}
