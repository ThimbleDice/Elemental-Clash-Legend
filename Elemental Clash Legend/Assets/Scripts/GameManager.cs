using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject[] players;
	public Vector3[] spawnPoints;
	public GameObject map;
	public GameObject HUD;

	public bool[] deadPlayer;
	public int currentPhase;
	public int currentPlayer;

	// Use this for initialization
	void Start () {
		InstantiateMap ();
		InstantiatePlayers ();
		InstantiateHUD ();
		currentPlayer = 0;
		MultiplayerEventManager.TimerEnd += SwitchPhase;
		MultiplayerEventManager.PlayerCast += SwitchPhase;
		MultiplayerEventManager.SpellEnd += SwitchPhase;
		MultiplayerEventManager.PlayerDead += PlayerDead;
		MultiplayerEventManager.PlayerWon += PlayerWon;
		MultiplayerEventManager.NextPlayerButtonClick += SwitchPhase;
		currentPhase = -1;
	}

	private void InstantiateMap()
	{
		map = Instantiate (map);
	}

	private void InstantiatePlayers()
	{
		deadPlayer = new bool[players.Length];
		for (int i = 0; i < players.Length; i++) {
			players [i] = Instantiate (players[i], spawnPoints[i], new Quaternion());
			players [i].GetComponent<MultiplayerPlayerId> ().SetId (i);
			deadPlayer [i] = false;
		}
		for (int i = 0; i < players.Length; i++) {
			MultiplayerEventManager.TriggerNextPlayer (currentPlayer, ((currentPlayer + 1) % players.Length));
			currentPlayer = (currentPlayer + 1) % players.Length;
		}
	}

	private void InstantiateHUD()
	{
		HUD = Instantiate (HUD);
		HUD.transform.Find ("WinMenu").gameObject.SetActive (false);
	}

	public void PlayerDead(int playerId)
	{
		deadPlayer [playerId] = true;
		if (playerId == currentPlayer)
			NextPlayer();
		CheckIfWinner();
	}

	public void CheckIfWinner()
	{
		int nbOfAlive = 0;
		int winnerId = -1;
		for (int i = 0; i < players.Length; i++)
			if (!deadPlayer[i]) {
				nbOfAlive++;
				winnerId = i;
			}
		if (nbOfAlive == 1) {
			MultiplayerEventManager.TriggerPlayerWon(winnerId);
		}
	}

	public void PlayerWon(int playerId)
	{
		HUD.transform.Find ("WinMenu").gameObject.SetActive (true);
		HUD.transform.Find ("WinMenu").GetComponent<WinMenu>().SetWinner ("Winner : Player " + (playerId + 1));
	}

	void SwitchPhase()
	{
		currentPhase = (currentPhase + 1) % 5;
		switch (currentPhase)
		{
		case 0:
			MultiplayerEventManager.TriggerAllowCurrentPlayerToMove(currentPlayer);
			break;
		case 1:
			MultiplayerEventManager.TriggerDisallowCurrentPlayerToMove(currentPlayer);
			break;
		case 2:
			MultiplayerEventManager.TriggerAllowCurrentPlayerToFire(currentPlayer);
			break;
		case 3:
			MultiplayerEventManager.TriggerDisallowCurrentPlayerToFire(currentPlayer);
			break;
		case 4:
			int lastPlayer = currentPlayer;
			NextPlayer ();
			MultiplayerEventManager.TriggerNextPlayer (lastPlayer, currentPlayer);
			break;
		default:
			break;
		}
	}

	private void NextPlayer()
	{
		int lastPlayer = currentPlayer;
		do {
			currentPlayer = (currentPlayer + 1) % players.Length;
		} while (deadPlayer[currentPlayer] && currentPlayer != lastPlayer);
		if (currentPlayer == lastPlayer) {
			PlayerWon (currentPlayer);
		}
	}
}
