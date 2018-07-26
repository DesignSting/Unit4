using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverview : MonoBehaviour {

    public Camera overViewCamera;
    public Canvas letterCanvas;
    public float cameraSpeed;
    private float runningSpeed;

    private float minXPos;
    private float minZPos;

    private float maxXPos;
    private float maxZPos;

    public bool inRange = false;
    public bool displayed = false;

    // Use this for initialization
    void Start ()
    {
        minXPos = overViewCamera.transform.position.x - (float)(0.6);
        maxXPos = overViewCamera.transform.position.x + (float)(0.1);

        minZPos = overViewCamera.transform.position.z - (float)(0.2);
        maxZPos = overViewCamera.transform.position.z + (float)(0.5);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (inRange)
            {
                overViewCamera.enabled = true;
                displayed = true;
            }
        }
        /*
        if(displayed)
        {
            runningSpeed = Time.deltaTime * cameraSpeed;
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (overViewCamera.transform.position.x <= maxXPos)
                    overViewCamera.transform.position = transform.position + new Vector3(runningSpeed, 2.4f, 0);
                Debug.Log("Left");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (overViewCamera.transform.position.x >= minXPos)
                    overViewCamera.transform.position = transform.position - new Vector3(runningSpeed, 2.4f, 0);
                Debug.Log("Right");
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (overViewCamera.transform.position.z >= maxZPos)
                    overViewCamera.transform.position = transform.position - new Vector3(0, 2.4f, runningSpeed);
                Debug.Log("Up");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (overViewCamera.transform.position.z <= minZPos)
                    overViewCamera.transform.position = transform.position + new Vector3(0, 2.4f, runningSpeed);
                Debug.Log("Down");
            }
        }
        */
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
            letterCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            overViewCamera.enabled = false;
            displayed = false;
            letterCanvas.enabled = false;
        }
    }
}
