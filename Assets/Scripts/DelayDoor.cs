using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDoor : MonoBehaviour {

    /*
    * Declaring Variables required for this method to run.
    * 
    * GameObject objectToTime, depending on the object different executions will occur
    * 
    * int maxTimer, the max time until the sound is played
    * float timer, the timer as it counts up from 0
    * 
    * bool isRunning, returns true is the timer is running
    * bool taskComplete, returns true when the task or action has completed
    * 
    */

    public GameObject objectToTime;
    public int maxTime;
    public float timer;

    public bool isRunning;
    public bool taskComplete;

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Start() is run at the beginning of the scene
     * 
     * Defines time to 0 and both isRunning and taskComplete to false
     * Also hides the cursor from the player
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        timer = 0;
        isRunning = false;
        taskComplete = false;
        Cursor.visible = false;
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Once isRunning is true will start the timer
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
     * Depending on the GameObject it will follow a different series of actions. But at the end it will execute the object. If it is a door it will open,
     * if it is a light it will turn it on if off or off if on and a sound will play.
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    public void DoAction()
    {
        if (!taskComplete)
        {
            if (objectToTime.tag == "Door")
            {
                AudioSource audioData = objectToTime.GetComponent<AudioSource>();
                audioData.enabled = true;
                objectToTime.GetComponent<QuickDoor>().openDoor = true;
                //objectToTime.GetComponentInParent<AudioSource>();
            }

            if (objectToTime.tag == "Light")
            {
                if (objectToTime.GetComponent<Light>().enabled == false)
                {
                    objectToTime.GetComponent<Light>().enabled = true;
                }
                else
                    objectToTime.GetComponent<Light>().enabled = false;
            }

            if( objectToTime.tag == "Sound")
            {
                AudioSource audioData = objectToTime.GetComponent<AudioSource>();
                audioData.enabled = true;
            }
            taskComplete = true;
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void OnTriggerEnter(Collider other) 
     * 
     * Trigger detection, Detects when the player passes into the trigger box of another object. Defines the bool isRunning to true
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
