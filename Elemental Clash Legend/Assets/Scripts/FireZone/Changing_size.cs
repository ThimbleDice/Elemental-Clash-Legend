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
        
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			temp = transform.localScale;
			if (temp.x <= 0.4f)
			{
				temp.x += 0.01f;
			}

			if (temp.y <= 0.4f)
			{
				temp.y += 0.01f;
			}

			transform.localScale = temp;
		}
		else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			temp = transform.localScale;
			if (temp.x >= 0)
			{
				temp.x -= 0.01f;
			}

			if (temp.y >= 0)
			{
				temp.y -= 0.01f;
			}

			transform.localScale = temp;
		}
	}
}
