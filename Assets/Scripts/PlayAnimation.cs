using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    /*
    * Declaring Variables required for this method to run.
    * 
    * Animator playAnimator, the animator which will be manipulated
    * 
    * int maxTimer, the max time until the sound is played
    * float timer, the timer as it counts up from 0
    * 
    * bool isRunning, returns true is the timer is running
    * 
    * 
    */

    public Animator playAnimator;

    public int maxTime;
    public float timer;

    public bool isRunning = false;

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Once the bool isRunning is true it begins the timer. Once reached it will call the method DoAction()
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
        }
        if (timer >= maxTime)
        {
            DoAction();
            isRunning = false;
        }

    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void DoAction() 
     * 
     * When called will play the sound attached to the Animator playAnimator
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    private void DoAction()
    {
        playAnimator.SetBool("LightOn", true);
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
        if(other.tag == "Player")
        {
            isRunning = true;
        }
    }
}
