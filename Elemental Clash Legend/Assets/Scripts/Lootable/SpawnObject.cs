using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    [SerializeField] public GameObject objetAFaireApparaitre;
	[SerializeField] public GameObject objetAFaireApparaitre2;
    Vector3 endroit_a_apparaitre;
    Quaternion rotationObjet;
    float randomPositionX;
    float randomPositionY;
    public float spawnTime = 1f;

    // Use this for initialization
    void Start () {
        rotationObjet = new Quaternion(0,0,0,0);
        randomizePosition();
        InvokeRepeating("InstantiatieObjet", spawnTime, spawnTime);
		MultiplayerEventManager.PlayerWon += MultiplayerEventManager_PlayerWon;
    }
	
	// Update is called once per frame
	void Update () {
        randomizePosition();
    }

    void MultiplayerEventManager_PlayerWon (int playerId)
    {
		CancelInvoke ("InstantiatieObjet");
    }

    private void InstantiatieObjet()
    {
        Instantiate(objetAFaireApparaitre, endroit_a_apparaitre, rotationObjet);
        Instantiate(objetAFaireApparaitre2, endroit_a_apparaitre, rotationObjet);
    }

    void randomizePosition()
    {
        randomPositionX = Random.Range(-4.0f, 8.0f);
        randomPositionY = 5;
        endroit_a_apparaitre = new Vector3(randomPositionX, randomPositionY, 0);
    }
}
