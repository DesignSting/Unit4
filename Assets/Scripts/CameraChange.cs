using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public Camera firstCamera;
    public Camera secondCamera;
    public bool turnOff;
    public bool doneOnce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (turnOff && !doneOnce)
            {
                if (firstCamera.enabled)
                {
                    firstCamera.enabled = false;
                    secondCamera.enabled = true;
                }

                else
                {
                    firstCamera.enabled = true;
                    secondCamera.enabled = false;
                }
                doneOnce = true;
            }
            else if(!turnOff)
            {
                if (firstCamera.enabled)
                {
                    firstCamera.enabled = false;
                    secondCamera.enabled = true;
                }

                else
                {
                    firstCamera.enabled = true;
                    secondCamera.enabled = false;
                }
            }
            
        }
    }
}
