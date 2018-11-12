using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForCharacter : MonoBehaviour {

    public List<AudioClip> audioClipsListJump = new List<AudioClip>();

    public AudioClip jumpSound;
    public AudioClip takingDamage;
    private AudioSource audiosource;

    //https://docs.unity3d.com/ScriptReference/Resources.Load.html
    //https://answers.unity.com/questions/1186480/how-do-i-create-an-array-for-sounds.html


    // Use this for initialization
    void Start () {
        audiosource = GetComponent<AudioSource>();

        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jumps/J1"));
        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jumps/J2"));
        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jumps/J3"));
        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jumps/J4"));

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
        audiosource.PlayOneShot(audioClipsListJump[Random.Range(0, audioClipsListJump.Count)]);
    }

    public void TakingDamageSound()
    {
        audiosource.PlayOneShot(takingDamage);
    }
}
