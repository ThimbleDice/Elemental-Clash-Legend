using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangePlayerActiveState : MonoBehaviour {

    [SerializeField] public GameObject fireZone;
    [SerializeField] public PlayerPlatformerController playerController;

    private void Awake()
    {
        if (fireZone == null)
            fireZone = transform.Find("FireZone").gameObject;
        if (playerController == null)
            playerController = GetComponent<PlayerPlatformerController>();
    }

    public void StartMovePhase()
    {
        if (playerController != null)
        {
            playerController.playerTurn = true;
        }
        else
            throw new MultiplayerException("PlayerPlatformerController cannot be found");
    }

    public void EndMovePhase()
    {
        if (playerController != null)
        {
            playerController.playerTurn = false;
        }
        else
            throw new MultiplayerException("PlayerPlatformerController cannot be found");
    }

    public void StartFirePhase()
    {
        if (fireZone != null)
        {
            fireZone.GetComponent<FireGun>().Activate();
            fireZone.SetActive(true);
        }
        else
            throw new MultiplayerException("FireZone cannot be found");
    }

    public void EndFirePhase()
    {
        if (fireZone != null)
        {
            fireZone.GetComponent<FireGun>().Deactivate();
            fireZone.SetActive(false);
        }
        else
            throw new MultiplayerException("FireZone cannot be found");
    }
}
