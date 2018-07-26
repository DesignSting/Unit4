using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayObject : MonoBehaviour {

    public GameObject objectToTime;
    public int maxTime;
    private float timer;

    public bool isRunning;
    public bool hasReached;

	void Start ()
    {
        timer = 0;
        isRunning = false;
        //hasReached = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isRunning)
        {
            timer += Time.deltaTime;
        }
        if(timer >= maxTime)
        {
            //hasReached = true;
            DoAction();
        }
	}

    private void DoAction()
    {

    }
}
