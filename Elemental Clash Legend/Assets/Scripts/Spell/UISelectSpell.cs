using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectSpell : MonoBehaviour {

	public Image[] SelectableSpell;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
		{
			SelectSpell (0);
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			SelectSpell (1);
		}
	}

	public void SelectSpell(int idSpell)
	{
		for (int i = 0; i < SelectableSpell.Length; i++) {
			SelectableSpell [i].enabled = false;
		}
		SelectableSpell [idSpell].enabled = true;
	}
}
