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
		currentPhase = -1;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M))
		{
			SceneManager.LoadScene (0);
		}
		if (Input.GetKeyDown(KeyCode.N))
		{
			SwitchPhase ();
		}
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
			MultiplayerEventManager.TriggerNextPlayer (currentPlayer, ((currentPlayer + 1) % players.Length));
			currentPlayer = (currentPlayer + 1) % players.Length;
			break;
		default:
			break;
		}
	}
}
