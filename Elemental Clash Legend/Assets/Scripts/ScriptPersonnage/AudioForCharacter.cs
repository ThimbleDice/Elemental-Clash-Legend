﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForCharacter : MonoBehaviour {

    public static List<AudioClip> audioClipsListJump = new List<AudioClip>();
    public static List<AudioClip> audioClipsListTakingDamage = new List<AudioClip>();
    public static List<AudioClip> audioClipsListAttack = new List<AudioClip>();
    public static List<AudioClip> audioClipsListDeath = new List<AudioClip>();
    public static List<AudioClip> audioClipsListFallDeath = new List<AudioClip>();
    public static List<AudioClip> audioClipsListExplosion = new List<AudioClip>();
    public static List<AudioClip> audioClipsListSpellCast = new List<AudioClip>();

    public static AudioClip Victory;
    public static AudioClip MenuSelectSound;
    public static AudioClip TirerSelectSound;
    public static AudioClip ErrorSound;
    private static AudioSource audiosource;

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

    public static void JumpSound()
    {
        audiosource.PlayOneShot(audioClipsListJump[Random.Range(0, audioClipsListJump.Count)]);
    }

    public static void TakingDamageSound()
    {
        audiosource.PlayOneShot(audioClipsListTakingDamage[Random.Range(0, audioClipsListTakingDamage.Count)]);
    }

    public static void FallDeathSound()
    {
        GameObject.FindGameObjectWithTag("GeneralAudio").GetComponent<AudioSource>();
        audiosource.PlayOneShot(audioClipsListFallDeath[Random.Range(0, audioClipsListFallDeath.Count)]);
    }

    public static void DeathSound()
    {
        audiosource.PlayOneShot(audioClipsListDeath[Random.Range(0, audioClipsListDeath.Count)]);
    }

    public static void AttackSound()
    {
        audiosource.PlayOneShot(audioClipsListAttack[Random.Range(0, audioClipsListAttack.Count)]);
    }

    public static void ExplosionSound()
    {
        audiosource.PlayOneShot(audioClipsListExplosion[Random.Range(0, audioClipsListExplosion.Count)]);
    }

    public static void CastASpell()
    {
        audiosource.PlayOneShot(audioClipsListSpellCast[Random.Range(0, audioClipsListSpellCast.Count)]);
    }

    public static void VictorySound()
    {
        audiosource.PlayOneShot(Victory);
    }

    public static void MenuSelectionSound()
    {
        audiosource.PlayOneShot(MenuSelectSound);
    }

    public static void FireSelectionSound()
    {
        audiosource.PlayOneShot(TirerSelectSound);
    }

    public static void TimerOrQuitSound()
    {
        audiosource.PlayOneShot(ErrorSound);
    }
}
