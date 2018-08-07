using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInteraction : MonoBehaviour {

    public GameObject door;
    public Canvas overViewCanvasOn;
    public ParticleSystem overViewParticle;

    public bool inRange = false;
    public bool displayed = false;
    public bool doorOpen = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioSource audioData = door.GetComponent<AudioSource>();
                audioData.enabled = true;
                door.GetComponent<QuickDoor>().openDoor = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
            overViewCanvasOn.GetComponent<Canvas>().enabled = true;
            overViewParticle.GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            displayed = false;
            overViewCanvasOn.GetComponent<Canvas>().enabled = false;
            overViewParticle.GetComponent<ParticleSystem>().Stop();
        }
    }
}
