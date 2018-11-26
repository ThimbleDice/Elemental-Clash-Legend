using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTimerTime : MonoBehaviour {

    [SerializeField] public Text second;
    [SerializeField] public Text tenthSecond;

    private float currentTime = 0;
    private bool enable = true;
    private float lastUpdatedTime = 0;

    private void Update()
    {
        if (enable)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
                currentTime = 0;
            if (currentTime == 0)
                MultiplayerEventManager.TriggerNextPhase();
        }
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (lastUpdatedTime - currentTime >= 0.1F)
        {
            lastUpdatedTime = currentTime;
            second.text = System.Math.Round(currentTime, 0).ToString();
            tenthSecond.text = System.Math.Round(((System.Math.Round(currentTime, 1) % 1)*10), 0).ToString();
        }
        if(currentTime == 0)
        {
            second.text = "0";
            tenthSecond.text = "0";
        }
    }

    public void Enable()
    {
        enable = true;
    }

    public void Disable()
    {
        enable = false;
    }

    public void ChangeTime(float newTime)
    {
        lastUpdatedTime = newTime;
        currentTime = newTime;
    }
}
