using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerManager : MonoBehaviour {

    [SerializeField] public Text currentPlayerHud;
    [SerializeField] public Text currentPhaseHud;
    [SerializeField] public changeTimerTime timer;

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
            currentPhaseHud.text = "Movement";
            playersChangeActiveState[currentPlayer].StartMovePhase();
            phase = 1;
            timer.ChangeTime(2.0f);
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
            currentPhaseHud.text = "End movement";
            playersChangeActiveState[currentPlayer].EndMovePhase();
            phase = 2;
            timer.ChangeTime(1.0f);
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
            currentPhaseHud.text = "Cast";
            playersChangeActiveState[currentPlayer].StartFirePhase();
            phase = 3;
            timer.ChangeTime(5.0f);
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
            currentPhaseHud.text = "End cast";
            playersChangeActiveState[currentPlayer].EndFirePhase();
            phase = 4;
            timer.ChangeTime(0.0f);
            timer.Disable();
        }
        catch (MultiplayerException e)
        {
            Debug.Log(e.Message);
        }
    }

    void NextPlayer()
    {
        currentPhaseHud.text = "Next player";
        players[currentPlayer].tag = "Enemy";
        currentPlayer = (currentPlayer + 1) % players.Length;
        players[currentPlayer].tag = "Player";
        phase = 0;
        currentPlayerHud.text = "Player " + (currentPlayer + 1);
        timer.Enable();
        timer.ChangeTime(0.6f);
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
