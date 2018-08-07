using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public AudioSource playSound;

    public int maxTime;
    public float timer;
    public float soundTimer;

    public bool isRunning = false;
    public bool playing = false;

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

    private void DoAction()
    {
        playSound.Play();
    }

    private void StopAction()
    {
        playSound.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isRunning = true;
        }
    }
}
