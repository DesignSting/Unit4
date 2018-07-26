using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public Animator playAnimator;

    public int maxTime;
    public float timer;

    public bool isRunning = false;

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

    private void DoAction()
    {
        playAnimator.SetBool("LightOn", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isRunning = true;
        }
    }
}
