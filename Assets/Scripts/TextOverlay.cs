using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOverlay : MonoBehaviour {

    public Canvas firstCanvas;
    public Canvas secondCanvas;
    public Canvas thirdCanvas;
    public Canvas fourthCanvas;
    private Canvas currentCanvas;

    public bool inRange;
    public bool taskComplete;

    public float maxTimer;
    public float timer;

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

    private void DoAction()
    {
        if(!taskComplete)
        {
           if(maxTimer == 8.5)
            {
                thirdCanvas.enabled = false;
                fourthCanvas.enabled = true;
                currentCanvas = fourthCanvas;
                maxTimer += 2.5f;
                taskComplete = true;
                
            }
            else if(maxTimer == 6)
            {
                secondCanvas.enabled = false;
                thirdCanvas.enabled = true;
                currentCanvas = thirdCanvas;
                maxTimer += 2.5f;
                if (fourthCanvas == null)
                    taskComplete = true;
            }
            else if(maxTimer == 3.5)
            {
                firstCanvas.enabled = false;
                secondCanvas.enabled = true;
                currentCanvas = secondCanvas;
                maxTimer += 2.5f;
                if (thirdCanvas == null)
                    taskComplete = true;
            }
            else if (maxTimer == 1)
            {
                firstCanvas.enabled = true;
                currentCanvas = firstCanvas;
                maxTimer += 2.5f;
                if (secondCanvas == null)
                    taskComplete = true;
            }
        }
        else
        {
            currentCanvas.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
    }
}
