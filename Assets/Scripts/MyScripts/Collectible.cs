/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{

    public float RotationSpeed;
    public int value;
    public float velocityUpDown;
    public float hightModifier = 0.75f;
    public bool isSpecial = false;

    private float referenceY;

    void Start()
    {
        referenceY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.Paused) return;
        transform.RotateAroundLocal(Vector3.up, Time.deltaTime * RotationSpeed);

        float y = transform.position.y + velocityUpDown * Time.deltaTime;

        if (y > referenceY + hightModifier || y < referenceY - hightModifier)
        {
            if (y > referenceY + hightModifier)
            {
                y = referenceY + hightModifier;
            }
            else
            {
                y = referenceY - hightModifier;
            }
            velocityUpDown *= -1;
        }
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CollisionSoundEffect collisionSoundEffect = GetComponent<CollisionSoundEffect>();
            AudioSource.PlayClipAtPoint(collisionSoundEffect.audioClip, transform.position, collisionSoundEffect.volumeModifier);
            Destroy(gameObject);
            GameData.Instance.Score += value;
            if (isSpecial)
            {
                GameData.Instance.SpecialCoins++;
            }
            else
            {
                GameData.Instance.Coins++;
            }
        }
    }
}
