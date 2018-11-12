using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplayerManager : MonoBehaviour {

    [SerializeField] public GameObject[] players;

    private int currentPlayer;

	// Use this for initialization
	void Start () {
        currentPlayer = 0;
        InitializePlayers();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextPlayer();
        }
    }

    void NextPlayer()
    {
        players[currentPlayer].GetComponent<PlayerPlatformerController>().playerTurn = false;
        currentPlayer = (currentPlayer + 1) % 2;
        print(currentPlayer);
        players[currentPlayer].GetComponent<PlayerPlatformerController>().playerTurn = true;
    }

    void InitializePlayers()
    {
        for (int i = 1; i < players.Length; i++)
            players[i].GetComponent<PlayerPlatformerController>().playerTurn = false;
    }
}
