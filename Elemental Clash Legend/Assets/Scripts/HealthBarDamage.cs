using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarDamage : MonoBehaviour {

   public SimpleHealthBar healthBar;
    int damage = 10;
    float health = 100;
    float maxHealth = 100;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update ()
    {    
        TakeDamage();
    }

    private void Awake()
    {
        healthBar = GetComponent<SimpleHealthBar>();
    }

    public void TakeDamage()
    {
     
        if (Input.GetKeyDown("space"))
        {
            health -= damage;
            healthBar.UpdateBar(health, maxHealth);      
            print("space key was pressed");
        }   
    }
}
