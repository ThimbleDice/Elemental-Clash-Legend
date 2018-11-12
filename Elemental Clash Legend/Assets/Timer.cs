using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime = 5.0f;
    private float endTime = 0.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        float currentTime = startTime - Time.time;

        TimerFinished(currentTime);

        string minutes = ((int)currentTime / 60).ToString();
        string secondes = (currentTime % 60).ToString("f0");

        timerText.text = minutes + ":" + secondes;
    }

    private void TimerFinished(float currentTime)
    {
        if (currentTime == endTime)
        {
            Debug.Log("OK");
            timerText.color = Color.red;
            return;
        }
    }
}
