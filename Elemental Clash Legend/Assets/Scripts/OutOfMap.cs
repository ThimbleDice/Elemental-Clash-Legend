using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour {

    public GameObject tilemapGameObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tilemapGameObject == collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
