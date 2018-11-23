using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPotion : MonoBehaviour {

    private Text potionHealth;
    private Text potionPower;
    int numberPotionHealth = 0;
    int numberPotionPower = 0;

    // Use this for initialization
    void Start () {
        potionHealth = GameObject.FindGameObjectWithTag("potionHealthHUD").GetComponent<Text>();
        potionPower = GameObject.FindGameObjectWithTag("potionPowerHUD").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        if(potionHealth != null && potionPower != null)
        {
            potionHealth.text = "Potion de vie : " + numberPotionHealth.ToString();
            potionPower.text = "Potion de pouvoir : " + numberPotionPower.ToString();
        }
    }

    public void CountPotionHealthWhenTouch()
    {
        numberPotionHealth += 1;        
    }

    public void CountPotionPowerWhenTouch()
    {
        numberPotionPower += 1;    
    }
}
