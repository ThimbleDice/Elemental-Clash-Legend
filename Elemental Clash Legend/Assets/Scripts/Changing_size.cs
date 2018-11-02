using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing_size : MonoBehaviour {

    public float speed = 5f;
    Vector2 temp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetAxis("Fire1") > 0)
        {

            temp = transform.localScale;
            if (temp.x <= 0.4f)
            {
                temp.x += 0.005f;
            }
            
            if (temp.y <= 0.4f)
            {
                temp.y += 0.005f;
            }
            
            transform.localScale = temp;

        } else if (Input.GetAxis("Fire2") > 0)

        {
            temp = transform.localScale;
            if (temp.x >= 0)
            {
                temp.x -= 0.005f;
            }

            if (temp.y >= 0)
            {
                temp.y -= 0.005f;
            }

            transform.localScale = temp;
        }
     
	}
}
