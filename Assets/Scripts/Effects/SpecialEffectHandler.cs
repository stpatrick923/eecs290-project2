/*
 * Author: Rajesh Cherukuri
 * EECS 290 Project 2
 */
using UnityEngine;
using System.Collections;

public class SpecialEffectHandler : MonoBehaviour {

    // Helper script to toggle the emit property of many particle systems.
    // It's attached to the root Game Object of a hierarcy. Then calling SetSpecialEffectActive will
    // enable or disable all particle systems in transform children.


    // helper variable to track if the particles are already on.
    private bool effectActive;

    public void SetSpecialEffectActive (bool on) {

	    // Only do something if we're actually changing the effects being on or off
	    if (on != effectActive) {
		
		    // Find a list of all ParticleEmitters that are in this object's transform children
		    ParticleEmitter[] childEmitters = GetComponentsInChildren<ParticleEmitter>();
		
		    // Go over all them
		    foreach (ParticleEmitter emitter in childEmitters) {
			    // turn them on or off
			    emitter.emit = on;
		    }
		
		    effectActive = on;
	    }
    }

}
