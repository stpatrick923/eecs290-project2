/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameData.Instance.dialog = dialog;
            Destroy(gameObject);
        }
    }
}
