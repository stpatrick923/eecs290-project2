/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource), typeof(SphereCollider), typeof(Rigidbody))]

public class Foot : MonoBehaviour {

    public float baseFootAudioVolume = 1.0f;
    public float soundEffectPitchRandomness = 0.05f;


    //void OnTriggerEnter (Collider other) {
    //    CollisionParticleEffect collisionParticleEffect = other.GetComponent("CollisionParticleEffect") as CollisionParticleEffect;
	
    //    if (collisionParticleEffect) {
    //        Instantiate(collisionParticleEffect.effect, transform.position, transform.rotation);
    //    }
	
    //    CollisionSoundEffect collisionSoundEffect = (CollisionSoundEffect)other.GetComponent("CollisionSoundEffect");

    //    if (collisionSoundEffect) {
    //        audio.clip = collisionSoundEffect.audioClip;
    //        audio.volume = collisionSoundEffect.volumeModifier * baseFootAudioVolume;
    //        audio.pitch = Random.Range(1.0f - soundEffectPitchRandomness, 1.0f + soundEffectPitchRandomness);
    //        audio.Play();		
    //    }
    //}

    void Reset() {
	    rigidbody.isKinematic = true;
	   // collider.isTrigger = true;
    }
}
