using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForCharacter : MonoBehaviour {

    public List<AudioClip> audioClipsListJump = new List<AudioClip>();
    public List<AudioClip> audioClipsListTakingDamage = new List<AudioClip>();
    public List<AudioClip> audioClipsListAttack = new List<AudioClip>();
    public List<AudioClip> audioClipsListDeath = new List<AudioClip>();
    public List<AudioClip> audioClipsListFallDeath = new List<AudioClip>();
    public List<AudioClip> audioClipsListExplosion = new List<AudioClip>();
    public List<AudioClip> audioClipsListSpellCast = new List<AudioClip>();

    public AudioClip Victory;
    public AudioClip MenuSelectSound;
    public AudioClip TirerSelectSound;
    public AudioClip ErrorSound;
    private AudioSource audiosource;

    void Start () {
        audiosource = GetComponent<AudioSource>();

        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jump/J1"));
        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jump/J2"));
        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jump/J3"));
        audioClipsListJump.Add((AudioClip)Resources.Load<AudioClip>("Jump/J4"));

        audioClipsListTakingDamage.Add((AudioClip)Resources.Load<AudioClip>("TalingDamage/TK1"));
        audioClipsListTakingDamage.Add((AudioClip)Resources.Load<AudioClip>("TalingDamage/TK2"));
        audioClipsListTakingDamage.Add((AudioClip)Resources.Load<AudioClip>("TalingDamage/TK3"));

        audioClipsListAttack.Add((AudioClip)Resources.Load<AudioClip>("Attack/A1"));
        audioClipsListAttack.Add((AudioClip)Resources.Load<AudioClip>("Attack/A2"));
        audioClipsListAttack.Add((AudioClip)Resources.Load<AudioClip>("Attack/A3"));
        audioClipsListAttack.Add((AudioClip)Resources.Load<AudioClip>("Attack/A4"));

        audioClipsListDeath.Add((AudioClip)Resources.Load<AudioClip>("Death/D1"));
        audioClipsListDeath.Add((AudioClip)Resources.Load<AudioClip>("Death/D2"));

        audioClipsListFallDeath.Add((AudioClip)Resources.Load<AudioClip>("FallDeath/FD1"));
        audioClipsListFallDeath.Add((AudioClip)Resources.Load<AudioClip>("FallDeath/FD2"));

        audioClipsListExplosion.Add((AudioClip)Resources.Load<AudioClip>("Explosion/E1"));
        audioClipsListExplosion.Add((AudioClip)Resources.Load<AudioClip>("Explosion/E2"));
        audioClipsListExplosion.Add((AudioClip)Resources.Load<AudioClip>("Explosion/E3"));
        audioClipsListExplosion.Add((AudioClip)Resources.Load<AudioClip>("Explosion/E4"));

        audioClipsListSpellCast.Add((AudioClip)Resources.Load<AudioClip>("SpellCasting/SC1"));
        audioClipsListSpellCast.Add((AudioClip)Resources.Load<AudioClip>("SpellCasting/SC2"));
        audioClipsListSpellCast.Add((AudioClip)Resources.Load<AudioClip>("SpellCasting/SC3"));
        audioClipsListSpellCast.Add((AudioClip)Resources.Load<AudioClip>("SpellCasting/SC4"));
        audioClipsListSpellCast.Add((AudioClip)Resources.Load<AudioClip>("SpellCasting/SC5"));
        audioClipsListSpellCast.Add((AudioClip)Resources.Load<AudioClip>("SpellCasting/SC6"));
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            CastASpell();
        }

    }

    public void JumpSound()
    {
        audiosource.PlayOneShot(audioClipsListJump[Random.Range(0, audioClipsListJump.Count)]);
    }

    public void TakingDamageSound()
    {
        audiosource.PlayOneShot(audioClipsListTakingDamage[Random.Range(0, audioClipsListTakingDamage.Count)]);
    }

    public void FallDeathSound()
    {
        audiosource.PlayOneShot(audioClipsListFallDeath[Random.Range(0, audioClipsListFallDeath.Count)]);
    }

    public void DeathSound()
    {
        audiosource.PlayOneShot(audioClipsListDeath[Random.Range(0, audioClipsListDeath.Count)]);
    }

    public void AttackSound()
    {
        audiosource.PlayOneShot(audioClipsListAttack[Random.Range(0, audioClipsListAttack.Count)]);
    }

    public void ExplosionSound()
    {
        audiosource.PlayOneShot(audioClipsListExplosion[Random.Range(0, audioClipsListExplosion.Count)]);
    }

    public void CastASpell()
    {
        audiosource.PlayOneShot(audioClipsListSpellCast[Random.Range(0, audioClipsListSpellCast.Count)]);
    }

    public void VictorySound()
    {
        audiosource.PlayOneShot(Victory);
    }

    public void MenuSelectionSound()
    {
        audiosource.PlayOneShot(MenuSelectSound);
    }

    public void FireSelectionSound()
    {
        audiosource.PlayOneShot(TirerSelectSound);
    }

    public void TimerOrQuitSound()
    {
        audiosource.PlayOneShot(ErrorSound);
    }
}
