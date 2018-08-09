using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticle : MonoBehaviour {


    /*
    * ParticleSystem overViewParticle, the the particle system to Play
    * 
    */

    public ParticleSystem toStart;

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerEnter(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Depending on the current state of the particle will either
     * Play or Stop the particles
     * 
     * Param:
     *      Collider other - the collider of any objects that this object passes into
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (toStart.GetComponent<ParticleSystem>().isPlaying == false)
                toStart.GetComponent<ParticleSystem>().Play();
            else
                toStart.GetComponent<ParticleSystem>().Stop();
        }
    }
}
