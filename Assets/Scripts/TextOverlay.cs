using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOverlay : MonoBehaviour {

    /*
    * Declaring Variables required for this method to run.
    * 
    * Canvas firstCanvas, the first canvas to be enabled
    * Canvas secondCanvas, the second canvas to be enabled
    * Canvas thirdCanvas, the third canvas to be enabled
    * Canvas fourthCanvas, the fourth canvas to be enabled
    * Canvas currentCanvas, the current cavas on the screen
    * 
    * bool isRunning, returns true is the timer is running
    * bool taskComplete, returns true after a select number of canvases has been displayed
    * 
    * float maxTimer, the max time until the sound is played
    * float timer, the timer as it counts up from 0
    * 
    * 
    */

    public Canvas firstCanvas;
    public Canvas secondCanvas;
    public Canvas thirdCanvas;
    public Canvas fourthCanvas;
    private Canvas currentCanvas;

    public bool inRange;
    public bool taskComplete;

    public float maxTimer;
    public float timer;

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void Update() is run every frame
     * 
     * Once the bool isRunning is true it begins the timer. Once reached it will call the method DoAction()
     * 
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------
    private void Update()
    {
        if(inRange)
        {
            timer += Time.deltaTime;
        }

        if(timer >= maxTimer)
        {
            DoAction();
        }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------

    /*
     * void DoAction() 
     * 
     * When called will enable a certain canvas and will terminate either when all canvases have been enabled and disabled or when a null value is reached
     * 
     * Param:
     *      Null
     * Return:
     *      Void
     */

    //---------------------------------------------------------------------------------------------------------------------------------------------------
    private void DoAction()
    {
        if(!taskComplete)
        {
           if(maxTimer == 10)
            {
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = true;
                currentCanvas = fourthCanvas;
                maxTimer += 3;
                taskComplete = true;
                
            }
            else if(maxTimer == 7)
            {
                secondCanvas.enabled = false;
                thirdCanvas.enabled = true;
                currentCanvas = thirdCanvas;
                maxTimer += 3;
                if (fourthCanvas == null)
                    taskComplete = true;
            }
            else if(maxTimer == 4)
            {
                firstCanvas.enabled = false;
                secondCanvas.enabled = true;
                currentCanvas = secondCanvas;
                maxTimer += 3;
                if (thirdCanvas == null)
                    taskComplete = true;
            }
            else if (maxTimer == 1)
            {
                firstCanvas.enabled = true;
                currentCanvas = firstCanvas;
                maxTimer += 3;
                if (secondCanvas == null)
                    taskComplete = true;
            }
        }
        else
        {
            currentCanvas.enabled = false;
        }
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
            inRange = true;
        }
    }
}
