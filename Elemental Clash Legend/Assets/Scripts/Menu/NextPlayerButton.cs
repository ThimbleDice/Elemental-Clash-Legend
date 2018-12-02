using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlayerButton : MonoBehaviour {
	[SerializeField] public GameObject NextButton;
	// Use this for initialization
	void Start () {
		MultiplayerEventManager.NextPlayer += NextPlayer;
	}

	private void NextPlayer(int currentPlayer, int nextPlayer)
	{
		NextButton.SetActive (true);
	}

	public void OnClickNextPlayer()
	{
		MultiplayerEventManager.TriggerNextPlayerButtonClick ();
		NextButton.SetActive (false);
	}
}
