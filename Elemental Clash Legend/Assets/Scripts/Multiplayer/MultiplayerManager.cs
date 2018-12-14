using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerManager : MonoBehaviour {

	public GameObject[] players;
	public Vector2[] spawnPoints;
	public GameObject HUD;

	private Text currentPlayerHud;
	private Text currentPhaseHud;
	private changeTimerTime timer;
	private GameObject winMenu;

	public PlayerData[] playersData;
    private int phase;
    private int currentPlayer;

    private void Awake()
    {
		/*
        MultiplayerEventManager.NextPhase += NextPhase;
        MultiplayerEventManager.AllowCurrentPlayerToMove += AllowCurrentPlayerToMove;
        MultiplayerEventManager.DisallowCurrentPlayerToMove += DisallowCurrentPlayerToMove;
        MultiplayerEventManager.AllowCurrentPlayerToFire += AllowCurrentPlayerToFire;
        MultiplayerEventManager.DisallowCurrentPlayerToFire += DisallowCurrentPlayerToFire;
		MultiplayerEventManager.NextPlayer += NextPlayer;
        MultiplayerEventManager.PlayerDead += PlayerDead;
        MultiplayerEventManager.PlayerWon += PlayerWon;
		Instantiate (HUD);
		*/
        currentPlayer = 0;
        phase = 0;
		currentPlayerHud = GameObject.FindGameObjectWithTag ("CurrentPlayerHud").GetComponent<Text> ();
		currentPhaseHud = GameObject.FindGameObjectWithTag ("CurrentPhaseHud").GetComponent<Text> ();
		timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<changeTimerTime> ();
		winMenu = GameObject.FindGameObjectWithTag ("WinMenu");
		winMenu.SetActive (false);
    }

    private void Start()
	{
		LoadPlayersData ();
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
    {/*
		print ("Next Phase");
		print (phase);
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
        } */
    }

    public void PlayerDead(int playerId)
    {
        playersData[playerId].dead = true;
        if (playerId == currentPlayer)
            NextPlayer();
        CheckIfWinner();
    }

    public void CheckIfWinner()
    {
        int nbOfAlive = 0;
        int winnerId = -1;
        for (int i = 0; i < playersData.Length; i++)
            if (!playersData[i].dead) {
                nbOfAlive++;
                winnerId = i;
            }     
        if (nbOfAlive == 1)
            MultiplayerEventManager.TriggerPlayerWon(winnerId);
    }

    public void PlayerWon(int playerId)
    {
		Time.timeScale = 0;
		if (winMenu == null) {
			winMenu = GameObject.FindGameObjectWithTag ("WinMenu");
		}
		winMenu.SetActive (true);
		WinMenu winMenuScript = winMenu.GetComponent<WinMenu> ();
		winMenuScript.SetWinner ("Winner : Player " + (playerId + 1));
    }

    void AllowCurrentPlayerToMove()
    {
        try
        {
			ChangePhaseHud("Movement");
			if (NeedToReloadPlayersData())
				ReloadPlayersData();
            //playersData[currentPlayer].changePlayerActiveState.StartMovePhase();
            phase = 1;
			changeTimerTime(2.0f);
			timer.Enable();
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
			ChangePhaseHud("End movement");
			if (NeedToReloadPlayersData())
				ReloadPlayersData();
			//playersData[currentPlayer].changePlayerActiveState.EndMovePhase();
            phase = 2;
			changeTimerTime(1.0f);
			timer.Enable();
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
			ChangePhaseHud("Cast");
			if (NeedToReloadPlayersData())
				ReloadPlayersData();
			//playersData[currentPlayer].changePlayerActiveState.StartFirePhase();
            phase = 3;
			changeTimerTime(5.0f);
			timer.Enable();
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
			ChangePhaseHud("End cast");
			if (NeedToReloadPlayersData())
				ReloadPlayersData();
			//playersData[currentPlayer].changePlayerActiveState.EndFirePhase();
            phase = 4;
			changeTimerTime(0.0f);
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
		ChangePhaseHud("Next player");
        playersData[currentPlayer].gameObject.tag = "Enemy";
        int lastPlayer = currentPlayer;
        do {
            currentPlayer = (currentPlayer + 1) % playersData.Length;
        } while (playersData[currentPlayer].dead && currentPlayer != lastPlayer);
        
        if (currentPlayer == lastPlayer){
            MultiplayerEventManager.TriggerPlayerWon(currentPlayer);
        }
        else
        {
            playersData[currentPlayer].gameObject.tag = "Player";
            phase = 0;
			ChangeCurrentPlayerHud("Player " + (currentPlayer + 1));
			changeTimerTime(4.0f);
            timer.Enable();
            PowerBarDamage powerBar = playersData[currentPlayer].gameObject.GetComponentInChildren<PowerBarDamage>();
            powerBar.IncreasePower(10);
        }
    }

    void InitializePlayers()
    {
		ChangePhaseHud("Initialize players");
		print (currentPhaseHud.text);
        for (int i = 0; i < playersData.Length; i++)
        {
			currentPlayer = i;
			//playersData[currentPlayer].changePlayerActiveState.EndMovePhase();
			//playersData[currentPlayer].changePlayerActiveState.EndFirePhase();
            playersData[currentPlayer].gameObject.tag = "Enemy";
            MultiplayerPlayerId playerId = playersData[currentPlayer].gameObject.GetComponent<MultiplayerPlayerId>();
            playerId.SetId(currentPlayer);
        }
		currentPlayer = 0;
		playersData[currentPlayer].gameObject.tag = "Player";
		ChangeCurrentPlayerHud("Player " + (currentPlayer + 1));
		phase = 0;
		changeTimerTime(2.0f);
		timer.Enable();
    }

	void ChangePhaseHud(string newText)
	{
		if (currentPhaseHud == null) {
			currentPhaseHud = GameObject.FindGameObjectWithTag ("CurrentPhaseHud").GetComponent<Text> ();
		}
		currentPhaseHud.text = newText;
	}

	void ChangeCurrentPlayerHud(string newText)
	{
		if (currentPlayerHud == null) {
			currentPlayerHud = GameObject.FindGameObjectWithTag ("CurrentPlayerHud").GetComponent<Text> ();
		}
		currentPlayerHud.text = newText;
	}

	void changeTimerTime(float newTime)
	{
		if (timer == null) {
			timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<changeTimerTime> ();
		}
		timer.ChangeTime(newTime);
	}

	bool NeedToReloadPlayersData()
	{
		for (int i = 0; i < playersData.Length; i++)
			if (playersData [i].gameObject != null)
				return false;
		return true;
	}

	void LoadPlayersData()
	{
		playersData = new PlayerData[players.Length];
		for (int i = 0; i < players.Length; i++){
			PlayerData player = new PlayerData();
			player.gameObject = Instantiate(players[i], new Vector3(spawnPoints[i].x, spawnPoints[i].y), new Quaternion());
			player.dead = false;
			player.changePlayerActiveState = player.gameObject.GetComponent<ChangePlayerActiveState> ();
			playersData[i] = player;
		}
	}

	void ReloadPlayersData()
	{
		GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		playersData = new PlayerData[(allPlayers.Length + allEnemies.Length)];
		for (int i = 0; i < allPlayers.Length; i++){
			PlayerData player = new PlayerData();
			player.gameObject = allPlayers[i];
			player.dead = false;
			player.changePlayerActiveState = allPlayers [i].GetComponent<ChangePlayerActiveState> ();
			playersData[allPlayers [i].GetComponent<MultiplayerPlayerId>().GetId()] = player;
		}
		for (int i = 0; i < allEnemies.Length; i++){
			PlayerData player = new PlayerData();
			player.gameObject = allEnemies[i];
			player.dead = false;
			player.changePlayerActiveState = allEnemies [i].GetComponent<ChangePlayerActiveState> ();
			playersData[allEnemies [i].GetComponent<MultiplayerPlayerId>().GetId()] = player;
		}
	}
}

public class PlayerData
{
    public GameObject gameObject;
    public bool dead;
	public ChangePlayerActiveState changePlayerActiveState;
}