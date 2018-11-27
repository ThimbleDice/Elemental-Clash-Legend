using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjet : MonoBehaviour {

    HealthBarDamage healthBar;
    PowerBarDamage powerBar;
    //CountPotion countPotion;
    // Use this for initialization
    void Start () {
        healthBar = GetComponentInChildren<HealthBarDamage>();
        powerBar = GetComponentInChildren<PowerBarDamage>();
        //countPotion = GetComponent<CountPotion>();
	}
	
	// Update is called once per frame
	void Update () {
     
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ObjetSante")
        {
            healthBar.IncreaseHealth(20);
            //countPotion.CountPotionHealthWhenTouch();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ObjetPotion")
        {
            powerBar.IncreasePower(20);
            //countPotion.CountPotionPowerWhenTouch();
            Destroy(collision.gameObject);
        }
    }
}
