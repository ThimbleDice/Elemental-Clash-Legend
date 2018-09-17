using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool shoot = Input.GetButton("Jump");
        shoot |= Input.GetButton("Fire2");
        // Astuce pour ceux sous Mac car Ctrl + flèches est utilisé par le système

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false : le joueur n'est pas un ennemi
                weapon.Attack(false);
            }
        }
    }
}
