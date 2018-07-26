using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public Camera firstCamera;
    public Camera secondCamera;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(firstCamera.enabled)
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
