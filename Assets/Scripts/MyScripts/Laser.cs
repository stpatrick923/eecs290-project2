/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    public float velocity;
    public int dmg;
    public Vector3 direction;


    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * velocity, Space.World);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            other.gameObject.SendMessage("PlayerHit", dmg, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
