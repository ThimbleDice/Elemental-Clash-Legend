using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour {
	public Text winnerText;
	public GameObject[] objectToDisable;

    public void MainMenu()
    {
		MultiplayerEventManager.UnsubscribeAllSubscriber ();
		Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

	public void SetWinner(string winner)
	{
		winnerText.text = winner;
		for (int i = 0; i < objectToDisable.Length; i++) {
			objectToDisable [i].SetActive (false);
		}
		AudioForCharacter.VictorySound ();
	}
}
