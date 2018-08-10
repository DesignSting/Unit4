using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    /*
    * Declaring Variables required for this method to run.
    * 
    * bool inRange, returns true while the polayer is within the trigger box
    * bool moving, returns true while the player is going between levels
    * bool first, returns true after the first footstep sounded
    * bool second, returns true after the second footstep sounded
    * bool third, returns true after the third footstep sounded
    * bool fourth, returns true after the fourth footstep sounded
    * bool isRunning, returns true when also moving between levels
    * 
    * Canvas transCanvas, is the canvas to be displayed to the player
    * AudioSource ladderStep, is the sound of the footstep
    * Animator playAnimator, is the animator to fade out the player
    * 
    * 
    * float maxTimer, the max time until the sound is played
    * float timer, the timer as it counts up from 0
    * float stepTimer, the timer just for the step sounds
    * 
    * 
    */

    public bool inRange = false;
    public bool moving = false;
    public bool first = false;
    public bool second = false;
    public bool third = false;
    public bool fourth = false;
    public bool isRunning = false;

    public Canvas transCanvas;
    public AudioSource ladderStep;

    public Animator playAnimator;

    public int maxTime;
    public float timer;
    public float stepTimer;


    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Listens to when the player presses the 'E' key. When done so it will call the method DoAction(). This will start the Animator and then call PlaySound()
     * This method will sound off 5 footsteps while the screen goes to black
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    void Update ()
    {
        stepTimer += Time.deltaTime;
		if(inRange && !moving)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                timer = 0;
                isRunning = true;
                stepTimer = 0;
                DoAction();
                moving = true;
            }
        }

        if (isRunning)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                isRunning = false;
                SceneManager.LoadScene(2);
                ladderStep.Stop();
            }
        }
        if(moving)
        {
            PlaySound();
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void DoAction() 
     * 
     * Calls playAnimator which starts the fade to black and also plays the first step sound
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void DoAction()
    {
        playAnimator.SetBool("CanFade", true);
        ladderStep.Play();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void PlaySound() 
     * 
     * When the variable stepTimer is between certain values will Play the sound ladderStep
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void PlaySound()
    {
        if(stepTimer >1.2f && stepTimer <1.3f && !first)
        {
            ladderStep.Play();
            first = true;
        }

        if (stepTimer > 2.3f && stepTimer < 2.4f && !second)
        {
            ladderStep.Play();
            second = true;
        }

        if (stepTimer > 3.4f && stepTimer < 3.5f && !third)
        {
            ladderStep.Play();
            third = true;
        }

        if (stepTimer > 4.5f && stepTimer < 4.6f && !fourth)
        {
            ladderStep.Play();
            fourth = true;
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerEnter(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Cheanges the bool isRange to true and displays the 
     * Canvas transCanvas
     * 
     * Param:
     *      Collider other - the collider of any objects that this object passes into
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            transCanvas.GetComponent<Canvas>().enabled = true;
        }
    }
}
