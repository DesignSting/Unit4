using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverview : MonoBehaviour {

    public Camera overViewCamera;
    public Canvas overViewCanvasOn;
    public Canvas overViewCanvasOff;
    public ParticleSystem overViewParticle;

    public bool inRange = false;
    public bool displayed = false;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (inRange && !displayed)
            {
                overViewCamera.enabled = true;
                displayed = true;
                overViewCanvasOn.GetComponent<Canvas>().enabled = false;
                overViewCanvasOff.GetComponent<Canvas>().enabled = true;
            }

            else if(displayed && Input.GetKeyDown(KeyCode.F))
            {

            }
            else if(displayed)
            {
                overViewCamera.enabled = false;
                displayed = false;
                overViewCanvasOn.GetComponent<Canvas>().enabled = true;
                overViewCanvasOff.GetComponent<Canvas>().enabled = false;
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
            overViewCamera.enabled = false;
            displayed = false;
            overViewCanvasOn.GetComponent<Canvas>().enabled = false;
            overViewCanvasOff.GetComponent<Canvas>().enabled = false;
            overViewParticle.GetComponent<ParticleSystem>().Stop();
        }
    }
}
