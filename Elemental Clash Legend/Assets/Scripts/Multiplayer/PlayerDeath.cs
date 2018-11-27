using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    private MultiplayerManager multiplayermanager;

	// Use this for initialization
	void Start () {
        multiplayermanager = GameObject.FindGameObjectWithTag("MultiplayerManager").GetComponent<MultiplayerManager>();
    }

    public void Death()
    {
        multiplayermanager.PlayerDeath(gameObject.GetComponent<MultiplayerPlayerId>().GetId());
    }
}
