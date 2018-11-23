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
        MultiplayerEventManager.NextPhase += NextPhase;
        MultiplayerEventManager.AllowCurrentPlayerToMove += AllowCurrentPlayerToMove;
        MultiplayerEventManager.DisallowCurrentPlayerToMove += DisallowCurrentPlayerToMove;
        MultiplayerEventManager.AllowCurrentPlayerToFire += AllowCurrentPlayerToFire;
        MultiplayerEventManager.DisallowCurrentPlayerToFire += DisallowCurrentPlayerToFire;
        MultiplayerEventManager.NextPlayer += NextPlayer;
        players = GameObject.FindGameObjectsWithTag("Player");
        playersChangeActiveState = new ChangePlayerActiveState[players.Length];
        for (int i = 0; i < players.Length; i++)
            playersChangeActiveState[i] = players[i].GetComponent<ChangePlayerActiveState>();
        currentPlayer = 0;
        phase = 0;
    }

    private void Start()
    {
        InitializePlayers();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            MultiplayerEventManager.TriggerNextPhase();
        }
    }

    void NextPhase()
    {
        switch (phase)
        {
            case 0:
                MultiplayerEventManager.TriggerAllowCurrentPlayerToMove();
                break;
            case 1:
                MultiplayerEventManager.TriggerDisallowCurrentPlayerToMove();
                break;
            case 2:
                MultiplayerEventManager.TriggerAllowCurrentPlayerToFire();
                break;
            case 3:
                MultiplayerEventManager.TriggerDisallowCurrentPlayerToFire();
                break;
            case 4:
                MultiplayerEventManager.TriggerNextPlayer();
                break;
            default:
                break;
        }
    }

    void PlayerDeath()
    {

    }

    void AllowCurrentPlayerToMove()
    {
        try
        {
            playersChangeActiveState[currentPlayer].StartMovePhase();
            phase = 1;
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
            phase = 2;
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
            phase = 3;
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
            phase = 4;
        }
        catch (MultiplayerException e)
        {
            Debug.Log(e.Message);
        }
    }

    void NextPlayer()
    {
        players[currentPlayer].tag = "Enemy";
        currentPlayer = (currentPlayer + 1) % players.Length;
        players[currentPlayer].tag = "Player";
        phase = 0;
    }

    void InitializePlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            currentPlayer = i;
            DisallowCurrentPlayerToMove();
            DisallowCurrentPlayerToFire();
            players[currentPlayer].tag = "Enemy";
        }
        NextPlayer();
    }
}
