using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    /*
    * Declaring Variables required for this method to run.
    * 
    * AudioSoruce playSound, the sound which will be played
    * 
    * int maxTimer, the max time until the sound is played
    * float timer, the timer as it counts up from 0
    * float soundTimer, the timer for the sound itself
    * 
    * bool isRunning, returns true is the timer is running
    * bool playing, returns true if the sound has run
    * 
    * 
    */

    public AudioSource playSound;

    public int maxTime;
    public float timer;
    public float soundTimer;

    public bool isRunning = false;
    public bool playing = false;

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Once the bool isRunning is true it begins the timer. Once reached it will call the method DoAction() and also start the second timer soundTimer
     * 
     * Once soundTimer has reached its limit it will call the method StopAction()
     * 
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
        }
        if (timer >= maxTime && !playing)
        {
            DoAction();
            playing = true;
            soundTimer = 0;
            isRunning = false;
        }
        if(playing)
        {
            soundTimer += Time.deltaTime;
            if(soundTimer >= 5)
            {
                StopAction();
            }
        }

    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void DoAction() 
     * 
     * When called will play the sound attached to the AudioSource playSound
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void DoAction()
    {
        playSound.Play();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void StopAction() 
     * 
     * When called will stop the sound attached to the GameObject playSound
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void StopAction()
    {
        playSound.Stop();
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerEnter(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Cheanges the bool isRunning to true to start the timer
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
            isRunning = true;
        }
    }
}
