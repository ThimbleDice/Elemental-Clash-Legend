using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTimerTime : MonoBehaviour {

    [SerializeField] public Text second;
    [SerializeField] public Text tenthSecond;

    private float currentTime = 0.0f;
    private bool enable = true;
    private float lastUpdatedTime = 0.0f;
	private int lastPhaseTriggerTimerEnd;
	private int phase;

	private void Start()
	{
		MultiplayerEventManager.AllowCurrentPlayerToMove += StartMovePhase;
		MultiplayerEventManager.DisallowCurrentPlayerToMove += EndMovePhase;
		MultiplayerEventManager.AllowCurrentPlayerToFire += StartFirePhase;
		MultiplayerEventManager.DisallowCurrentPlayerToFire += EndFirePhase;
		MultiplayerEventManager.NextPlayer += NextPlayer;
	}

    private void Update()
    {
        if (enable)
        {
            currentTime -= Time.deltaTime;
			if (currentTime < 0.0f) {
				currentTime = 0.0f;
			}
			if (currentTime == 0.0f) {
				Disable ();
				lastPhaseTriggerTimerEnd = phase;
				MultiplayerEventManager.TriggerTimerEnd();
			}
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

	private void StartMovePhase(int currentPlayer)
	{
		phase = 0;
		ChangeTime (2.0f);
		Enable ();
	}

	private void EndMovePhase(int currentPlayer)
	{
		phase = 1;
		ChangeTime (1.0f);
		Enable ();
	}

	private void StartFirePhase(int currentPlayer)
	{
		phase = 2;
		ChangeTime (3.0f);
		Enable ();
	}

	private void EndFirePhase(int currentPlayer)
	{
		phase = 3;
		ChangeTime (0.0f);
		if (lastPhaseTriggerTimerEnd == 2) {
			Enable ();
		} else {
			Disable ();
		}

	}

	private void NextPlayer(int currentPlayer, int nextPlayer)
	{
		phase = 4;
		ChangeTime (0.0f);
		Disable ();
	}
}
