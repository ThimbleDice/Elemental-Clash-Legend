﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDestruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("123123123");
    }
}
