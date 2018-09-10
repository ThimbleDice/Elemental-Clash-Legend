using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarDamage : MonoBehaviour {

    public SimpleHealthBar healthBar;
    int damage = 50;
    float health = 90;
    float maxHealth = 100;
    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {

        takeDamage();
    }

    public void takeDamage()
    {
        if(Input.GetKeyDown("space"))
           {
            health -= damage;
            healthBar.UpdateBar(health, maxHealth);
            print("space key was pressed");
        }
     
    }
}
