using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime = 5.0f;
    private float endTime = 0.0f;
    private float currentTime;
	// Use this for initialization
	void Start () {
        currentTime = startTime;
	}
	
	// Update is called once per frame
	void Update () {

        currentTime = currentTime - Time.deltaTime;

        TimerFinished(currentTime);

        string minutes = ((int)currentTime / 60).ToString();
        string secondes = (currentTime % 60).ToString("f0");

        timerText.text = minutes + ":" + secondes;
    }

    private void TimerFinished(float currentTime)
    {
        if (currentTime <= 0)
        {
            timerText.color = Color.red;
        }
    }
}
