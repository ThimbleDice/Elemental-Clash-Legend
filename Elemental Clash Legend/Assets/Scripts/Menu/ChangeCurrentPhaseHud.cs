using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCurrentPhaseHud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MultiplayerEventManager.AllowCurrentPlayerToMove += StartMovePhase;
		MultiplayerEventManager.DisallowCurrentPlayerToMove += EndMovePhase;
		MultiplayerEventManager.AllowCurrentPlayerToFire += StartFirePhase;
		MultiplayerEventManager.DisallowCurrentPlayerToFire += EndFirePhase;
		MultiplayerEventManager.NextPlayer += NextPlayer;
	}

	private void StartMovePhase(int currentPlayer)
	{
		gameObject.GetComponent<Text> ().text = "Move";
	}

	private void EndMovePhase(int currentPlayer)
	{
		gameObject.GetComponent<Text> ().text = "End move";
	}

	private void StartFirePhase(int currentPlayer)
	{
		gameObject.GetComponent<Text> ().text = "Cast";
	}

	private void EndFirePhase(int currentPlayer)
	{
		gameObject.GetComponent<Text> ().text = "End cast";
	}

	private void NextPlayer(int currentPlayer, int nextPlayer)
	{
		gameObject.GetComponent<Text> ().text = "Next player";
	}
}
