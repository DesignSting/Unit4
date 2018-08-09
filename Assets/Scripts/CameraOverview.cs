using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverview : MonoBehaviour {


    /*
    * Declaring Variables required for this method to run.
    * 
    * Camera overViewCamera, is the camera to go over the current view
    * Canvas overViewCanvasOn, this is the canvas that will be displayed
    * Canvas overViewCanvasOn, this is the canvas that will be displayed while displayed is true
    * 
    * ParticleSystem overViewParticle, the the particle system to be manipulated
    * 
    * Light overViewLight, used in some instances to bring light to an object
    * 
    * bool inRange, will return true when the player is within the trigger collider
    * bool displayed, will return true if currently displayed to the player
    * 
    */

    public Camera overViewCamera;
    public Canvas overViewCanvasOn;
    public Canvas overViewCanvasOff;
    public ParticleSystem overViewParticle;
    public Light overViewLight;

    public bool inRange = false;
    public bool displayed = false;

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Once the player presses the letter 'E' on the keyboard a set of instructions will be followed. If inRange & displayed is false then the overview
     * camera will come on and the canvas will change. If the player presses it again then the opposite will occur
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (inRange && !displayed)
            {
                if(overViewCamera != null)
                    overViewCamera.enabled = true;
                displayed = true;
                overViewCanvasOn.GetComponent<Canvas>().enabled = false;
                overViewCanvasOff.GetComponent<Canvas>().enabled = true;
                if (overViewLight != null)
                    overViewLight.enabled = true;
            }

            else if(displayed)
            {
                if (overViewCamera != null)
                    overViewCamera.enabled = false;
                displayed = false;
                overViewCanvasOn.GetComponent<Canvas>().enabled = true;
                overViewCanvasOff.GetComponent<Canvas>().enabled = false;
                if (overViewLight != null)
                    overViewLight.enabled = false;
            }
        }
	}

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerEnter(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Defines inRange to true and enables the canvas 
     * overViewCanvasOn as well as plays the particle defined above
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
            inRange = true;
            overViewCanvasOn.GetComponent<Canvas>().enabled = true;
            if(overViewParticle != null)
                overViewParticle.GetComponent<ParticleSystem>().Play();
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerExit(Collider other) 
     * 
     * Trigger detection, Detects when the player leaves the trigger box of another object. Defines inRange to false and regardless of the current canvas
     * on screen will define them both as false. Also stops the current particle effect
     * 
     * Param:
     *      Collider other - the collider of any objects that this object passes into
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            if (overViewCamera != null)
                overViewCamera.enabled = false;
            displayed = false;
            overViewCanvasOn.GetComponent<Canvas>().enabled = false;
            overViewCanvasOff.GetComponent<Canvas>().enabled = false;
            if(overViewParticle != null)
                overViewParticle.GetComponent<ParticleSystem>().Stop();
        }
    }
}
