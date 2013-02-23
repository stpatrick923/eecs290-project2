/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float BumpSpeed;
    public int hp;
    public GameObject onDeathScript;
    public bool invincible;
    public int value;
	
	// Update is called once per frame

    void PlayerHit(int dmg)
    {
        if (invincible) return;

        hp-=dmg;
        if (hp <= 0)
        {
            GameData.Instance.Score += value;
            destroyEnemy();
        }
     }

    void OnDeath()
    {
        destroyEnemy();
    }

    void destroyEnemy()
    {
        Instantiate(onDeathScript, transform.position, transform.rotation);
        if (invincible) return;
        Destroy(gameObject);
    }

    void OnPlayerKilled()
    {
        Instantiate(onDeathScript, transform.position, transform.rotation);
    }
}
