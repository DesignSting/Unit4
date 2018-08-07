using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticle : MonoBehaviour {

    public ParticleSystem toStart;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            toStart.GetComponent<ParticleSystem>().Play();
        }
    }
}
