using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    public bool inRange = false;
    public bool moving = false;
    public bool first = false;
    public bool second = false;
    public bool third = false;
    public bool fourth = false;

    public Canvas transCanvas;
    public AudioSource ladderStep;

    public Animator playAnimator;

    public int maxTime;
    public float timer;
    public float stepTimer;

    public bool isRunning = false;


	
	// Update is called once per frame
	void Update ()
    {
        stepTimer += Time.deltaTime;
		if(inRange && !moving)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                timer = 0;
                isRunning = true;
                stepTimer = 0;
                DoAction();
                moving = true;
            }
        }

        if (isRunning)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                isRunning = false;
                SceneManager.LoadScene(2);
                ladderStep.Stop();
            }
        }
        if(moving)
        {
            PlaySound();
        }
    }

    private void DoAction()
    {
        //ladderStep.Play();
        playAnimator.SetBool("CanFade", true);
        ladderStep.Play();
    }
    private void PlaySound()
    {
        if(stepTimer >1.2f && stepTimer <1.3f && !first)
        {
            ladderStep.Play();
            first = true;
        }

        if (stepTimer > 2.3f && stepTimer < 2.4f && !second)
        {
            ladderStep.Play();
            second = true;
        }

        if (stepTimer > 3.4f && stepTimer < 3.5f && !third)
        {
            ladderStep.Play();
            third = true;
        }

        if (stepTimer > 4.5f && stepTimer < 4.6f && !fourth)
        {
            ladderStep.Play();
            fourth = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            transCanvas.GetComponent<Canvas>().enabled = true;
        }
    }
}
