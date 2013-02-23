/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class OnDeathDestroy : MonoBehaviour {

    void OnDeath()
    {
        DestroyObject(gameObject);
    }
}
