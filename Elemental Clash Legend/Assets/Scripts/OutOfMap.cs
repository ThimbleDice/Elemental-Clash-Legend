﻿using System.Collections;
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tilemapGameObject == collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}