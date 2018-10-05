using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjet : MonoBehaviour {

    HealthBarDamage healthBar;
    PowerBarDamage powerBar;
    // Use this for initialization
    void Start () {
        healthBar = GetComponentInChildren<HealthBarDamage>();
        powerBar = GetComponentInChildren<PowerBarDamage>();
	}
	
	// Update is called once per frame
	void Update () {
     
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ObjetSante")
        {
            healthBar.IncreaseHealth();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "ObjetPotion")
        {
            powerBar.IncreasePower();
            Destroy(collision.gameObject);
        }
    }
}
