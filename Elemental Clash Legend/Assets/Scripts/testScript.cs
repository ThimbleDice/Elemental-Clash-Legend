using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {
	 public GameObject manager;
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
		{
			manager.SetActive (true);
		}
	}
}
