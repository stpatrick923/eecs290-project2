/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class Lerpz : MonoBehaviour
{

    void OnDeath()
    {
        GameData.Instance.Deaths += 1; 
        gameObject.GetComponent<PlatformerController>().Spawn();
    }
}
