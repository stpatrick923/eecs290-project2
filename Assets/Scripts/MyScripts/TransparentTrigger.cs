/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class TransparentTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        transform.parent.SendMessage("OnTriggerEnter", collider);
    }
}
