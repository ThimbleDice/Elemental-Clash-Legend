using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForCharacter : MonoBehaviour {

    public AudioClip jumpSound;
    public AudioClip takingDamage;
    private AudioSource audiosource;




	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButtonDown("Jump"))
        {
            JumpSound();
        }
    }

    public void JumpSound()
    {
        audiosource.PlayOneShot(jumpSound);
    }

    public void TakingDamageSound()
    {
        audiosource.PlayOneShot(takingDamage);
    }
}
