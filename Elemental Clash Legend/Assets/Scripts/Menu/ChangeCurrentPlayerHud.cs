using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCurrentPlayerHud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MultiplayerEventManager.NextPlayer += NextPlayer;
	}

	public void NextPlayer(int currentPlayer, int nextPlayer)
	{
		gameObject.GetComponent<Text> ().text = "Player " + (nextPlayer + 1);
	}
}
