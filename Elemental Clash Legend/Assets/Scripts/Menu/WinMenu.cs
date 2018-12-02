using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour {
	public Text winnerText;
    public void MainMenu()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene(0);
		SceneManager.UnloadSceneAsync (1);
    }

	public void SetWinner(string winner)
	{
		winnerText.text = winner;
	}
}
