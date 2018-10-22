using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalSheep : MonoBehaviour {

    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start () {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb2D.AddForce(new Vector2(10, 0));
    }
}
