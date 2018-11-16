using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour {

    private GameObject[] players;
    private ChangePlayerActiveState[] playersChangeActiveState;
    private int phase;

    private int currentPlayer;

    private void Awake()
    {
        NextPhaseTrigger.NextPhase.AddListener(NextPhase);//A réviser
        players = GameObject.FindGameObjectsWithTag("Player");
        playersChangeActiveState = new ChangePlayerActiveState[players.Length];
        for (int i = 0; i < players.Length; i++)
            playersChangeActiveState[i] = players[i].GetComponent<ChangePlayerActiveState>();
        currentPlayer = 0;
        phase = 0;
        InitializePlayers();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextPhase();
        }
    }

    void NextPhase()
    {
        switch (phase)
        {
            case 0:
                AllowCurrentPlayerToMove();
                phase ++;
                break;
            case 1:
                DisallowCurrentPlayerToMove();
                phase ++;
                break;
            case 2:
                AllowCurrentPlayerToFire();
                phase ++;
                break;
            case 3:
                DisallowCurrentPlayerToFire();
                phase ++;
                break;
            case 4:
                NextPlayer();
                phase = 0;
                break;
            default:
                break;
        }
    }

    void AllowCurrentPlayerToMove()
    {
        try
        {
            playersChangeActiveState[currentPlayer].StartMovePhase();
        }
        catch (MultiplayerException e)
        {
            Debug.Log(e.Message);
        }
    }

    void DisallowCurrentPlayerToMove()
    {
        try
        {
            playersChangeActiveState[currentPlayer].EndMovePhase();
        }
        catch (MultiplayerException e)
        {
            Debug.Log(e.Message);
        }
    }

    void AllowCurrentPlayerToFire()
    {
        try
        {
            playersChangeActiveState[currentPlayer].StartFirePhase();
        }
        catch (MultiplayerException e)
        {
            Debug.Log(e.Message);
        }
    }

    void DisallowCurrentPlayerToFire()
    {
        try
        {
            playersChangeActiveState[currentPlayer].EndFirePhase();
        }
        catch (MultiplayerException e)
        {
            Debug.Log(e.Message);
        }
    }

    void NextPlayer()
    {
        currentPlayer = (currentPlayer + 1) % 2;
    }

    void InitializePlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerPlatformerController>().playerTurn = false;
            players[i].transform.Find("FireZone").gameObject.SetActive(false);
        }
    }
}
