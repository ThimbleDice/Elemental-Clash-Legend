using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHover : MonoBehaviour {
	
    public void MainMenuHoverEnter()
    {
        gameObject.GetComponentInChildren<Text>().color = Color.gray;
    }

    public void MainMenuHoverExit()
    {
        gameObject.GetComponentInChildren<Text>().color = Color.white;
    }

}
