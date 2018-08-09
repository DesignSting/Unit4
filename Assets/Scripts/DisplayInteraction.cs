using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInteraction : MonoBehaviour {


    /*
    * Declaring Variables required for this method to run.
    * 
    * GameObject door, this object is a door and will be manipulated by its own scripts
    * Canvas overViewCanvasOn, this is the canvas that will be displayed
    * ParticleSystem overViewParticle, this is the particle that will start
    * 
    * bool inRange, will return true when the player is within the trigger collider
    * bool displayed, will return true if currently displayed to the player
    * bool doorOpen, will return true once the door has executed its action
    * 
    */

    public GameObject door;
    public Canvas overViewCanvasOn;
    public ParticleSystem overViewParticle;

    public bool inRange = false;
    public bool displayed = false;
    public bool doorOpen = false;



    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Once the player presses the letter 'E' on the keyboard a set of instructions will be followed. Sound be played, script on the door object to execute
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

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

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerEnter(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Defines the bool inRange to true, also displays the canvas
     * overViewCanvasOn as well as plays the selected Particle
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
            overViewParticle.GetComponent<ParticleSystem>().Play();
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerExit(Collider other) 
     * 
     * Trigger detection, Detects when the player leaves the trigger box of another object. Defines the bool inRange to false, also hides the canvas
     * overViewCanvasOn as well as Pstops the selected Particle
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
            displayed = false;
            overViewCanvasOn.GetComponent<Canvas>().enabled = false;
            overViewParticle.GetComponent<ParticleSystem>().Stop();
        }
    }
}
