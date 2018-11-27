using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerManager : MonoBehaviour {

    [SerializeField] public Text currentPlayerHud;
    [SerializeField] public Text currentPhaseHud;
    [SerializeField] public changeTimerTime timer;

    private List<GameObject> players = new List<GameObject>();
    private List<ChangePlayerActiveState> playersChangeActiveState = new List<ChangePlayerActiveState>();
    private int phase;
    private int deadPlayeCount = 0;
    private int currentPlayer;

    private void Awake()
    {
        print(GameObject.FindGameObjectsWithTag("Player").Length);
        MultiplayerEventManager.NextPhase += NextPhase;
        MultiplayerEventManager.AllowCurrentPlayerToMove += AllowCurrentPlayerToMove;
        MultiplayerEventManager.DisallowCurrentPlayerToMove += DisallowCurrentPlayerToMove;
        MultiplayerEventManager.AllowCurrentPlayerToFire += AllowCurrentPlayerToFire;
        MultiplayerEventManager.DisallowCurrentPlayerToFire += DisallowCurrentPlayerToFire;
        MultiplayerEventManager.NextPlayer += NextPlayer;
        GameObject[] allPlayer = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            GameObject player = allPlayer[i];
            players.Add(player);
        }
        foreach (GameObject player in players)
            playersChangeActiveState.Add(player.GetComponent<ChangePlayerActiveState>());
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

    public void PlayerDeath(int playerId)
    {
        players.RemoveAt(playerId);
        UpdatePlayersId();
    }

    void UpdatePlayersId()
    {
        int newId = 0;
        foreach (GameObject player in players)
        {
            MultiplayerPlayerId playerId = player.GetComponent<MultiplayerPlayerId>();
            playerId.SetId(newId);
            newId++;
        }
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
            if (GameObject.FindGameObjectWithTag("Effet") == null)
                NextPhase();
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
        currentPlayer = (currentPlayer + 1) % players.Count;
        players[currentPlayer].tag = "Player";
        phase = 0;
        currentPlayerHud.text = "Player " + (currentPlayer + 1);
        timer.Enable();
        timer.ChangeTime(4.0f);
        PowerBarDamage powerBar = players[currentPlayer].GetComponentInChildren<PowerBarDamage>();
        powerBar.IncreasePower(10);
    }

    void InitializePlayers()
    {
        for (int i = 0; i < players.Count; i++)
        {
            currentPlayer = i;
            DisallowCurrentPlayerToMove();
            DisallowCurrentPlayerToFire();
            players[currentPlayer].tag = "Enemy";
            MultiplayerPlayerId playerId = players[currentPlayer].GetComponent<MultiplayerPlayerId>();
            playerId.SetId(currentPlayer);
        }
        NextPlayer();
        timer.ChangeTime(0.6f);
    }
}
