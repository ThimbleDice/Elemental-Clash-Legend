using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour {

    private GameObject tilemapGameObject;

    void Start()
    {
        tilemapGameObject = GameObject.FindGameObjectWithTag("OutOfMap");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tilemapGameObject == collision.gameObject)
        {
            FallOutOfMap();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tilemapGameObject == collision.gameObject)
        {
            FallOutOfMap();
        }
    }

    private void FallOutOfMap()
    {
        if (gameObject.tag == "Player" || gameObject.tag == "Enemy")
        {
            AudioForCharacter.FallDeathSound();
            PlayerDeath playerDeath =  gameObject.GetComponent<PlayerDeath>();
            playerDeath.Death();
        }
        Destroy(gameObject);
    }
}
