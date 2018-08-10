using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPhase : MonoBehaviour {

    /*
    * Declaring Variables required for this method to run.
    * 
    * Canvas overViewCanvasOn, this is the canvas that will be displayed
    * 
    * bool inRange, will return true when the player is within the trigger collider
    * 
    */

    public Canvas overViewCanvasOn;

    public bool inRange = false;

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Once the player presses the letter 'E' on the keyboard a set of instructions will be followed. It will load the Scene designated to 3
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerEnter(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Defines the bool inRange to true, also displays the canvas
     * overViewCanvasOn
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
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerExit(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Defines the bool inRange to true, also hides the canvas
     * overViewCanvasOn
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
            overViewCanvasOn.GetComponent<Canvas>().enabled = false;
        }
    }
}
