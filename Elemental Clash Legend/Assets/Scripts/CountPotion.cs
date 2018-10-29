using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPotion : MonoBehaviour {

    public Text potionHealth;
    public Text potionPower;
    int numberPotionHealth = 0;
    int numberPotionPower = 0;

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        potionHealth.text = "Potion de vie : " + numberPotionHealth.ToString();
        potionPower.text = "Potion de pouvoir : " + numberPotionPower.ToString();
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
