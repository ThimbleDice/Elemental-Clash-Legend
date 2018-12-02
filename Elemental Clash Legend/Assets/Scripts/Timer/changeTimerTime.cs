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
				MultiplayerEventManager.TriggerNextPhase();
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
		ChangeTime (2.0f);
		Enable ();
	}

	private void EndMovePhase(int currentPlayer)
	{
		ChangeTime (1.0f);
		Enable ();
	}

	private void StartFirePhase(int currentPlayer)
	{
		ChangeTime (3.0f);
		Enable ();
	}

	private void EndFirePhase(int currentPlayer)
	{
		ChangeTime (0.0f);
		Disable ();
	}

	private void NextPlayer(int currentPlayer, int nextPlayer)
	{
		ChangeTime (5.0f);
		Enable ();
	}
}
