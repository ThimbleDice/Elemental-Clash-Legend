using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangePlayerActiveState : MonoBehaviour {

    [SerializeField] public GameObject fireZone;
	[SerializeField] public PlayerPlatformerController playerController;
	[SerializeField] public MultiplayerPlayerId playerId;

    private void Start()
    {
        if (fireZone == null)
            fireZone = transform.Find("FireZone").gameObject;
		if (playerController == null)
			playerController = gameObject.GetComponent<PlayerPlatformerController> ();
		if (playerId == null)
			playerId = gameObject.GetComponent<MultiplayerPlayerId> ();

		MultiplayerEventManager.AllowCurrentPlayerToMove += StartMovePhase;
		MultiplayerEventManager.DisallowCurrentPlayerToMove += EndMovePhase;
		MultiplayerEventManager.AllowCurrentPlayerToFire += StartFirePhase;
		MultiplayerEventManager.DisallowCurrentPlayerToFire += EndFirePhase;
		MultiplayerEventManager.NextPlayer += NextPlayer;
    }

	public void StartMovePhase(int currentPlayer)
	{
		if (currentPlayer == playerId.GetId ()) {
			if (playerController != null) {
				playerController.playerTurn = true;
			} else
				throw new MultiplayerException("StartMovePhase : PlayerPlatformerController cannot be found");
		}
    }

	public void EndMovePhase(int currentPlayer)
	{
		if (currentPlayer == playerId.GetId ()) {
			if (playerController != null)
			{
				playerController.playerTurn = false;
			} else
				throw new MultiplayerException("EndMovePhase : PlayerPlatformerController cannot be found");
		}
    }

	public void StartFirePhase(int currentPlayer)
	{
		if (currentPlayer == playerId.GetId ()) {
			if (fireZone != null)
			{
				fireZone.GetComponent<FireGun>().Activate();
				fireZone.SetActive(true);
			}
			else
				throw new MultiplayerException("StartFirePhase : FireZone cannot be found");
		}
    }

	public void EndFirePhase(int currentPlayer)
    {
		if (currentPlayer == playerId.GetId ()) {
			if (fireZone != null)
			{
				fireZone.GetComponent<FireGun>().Deactivate();
				fireZone.SetActive(false);
			}
			else
				throw new MultiplayerException("EndFirePhase : FireZone cannot be found");
		}
    }

	public void NextPlayer(int currentPlayer, int nextPlayer)
	{
		if (currentPlayer == playerId.GetId ()) {
			gameObject.tag = "Enemy";
		} else if(nextPlayer == playerId.GetId ()) {
			gameObject.tag = "Player";
		}
	}
}
