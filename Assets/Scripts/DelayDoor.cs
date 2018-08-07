using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDoor : MonoBehaviour {

    public GameObject objectToTime;
    public int maxTime;
    public float timer;

    public bool isRunning;
    public bool taskComplete;

    void Start()
    {
        timer = 0;
        isRunning = false;
        taskComplete = false;
    }

    // Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isRunning = true;
        }
    }
}
