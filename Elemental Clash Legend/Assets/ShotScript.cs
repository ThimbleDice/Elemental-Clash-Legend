using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    // Use this for initialization
    public int damage = 1;
    public bool isEnemyShot = false;
	void Start () {
        Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(1, 0, 0));
	}
}
