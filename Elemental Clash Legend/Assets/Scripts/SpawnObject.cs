using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    [SerializeField] GameObject objetAFaireApparaitre;
    [SerializeField] GameObject objetAFaireApparaitre2;
    Vector3 endroit_a_apparaitre;
    Quaternion rotationObjet;
    float randomPositionX;
    float randomPositionY;

    // Use this for initialization
    void Start () {
        rotationObjet = new Quaternion(0,0,0,0);
        randomizePosition();
        InstantiatieObjet();
    }
	
	// Update is called once per frame
	void Update () {
        randomizePosition();
        if (Input.GetKeyDown("space"))
        {
            InstantiatieObjet();
        }
    }

    private void InstantiatieObjet()
    {
        objetAFaireApparaitre = GameObject.FindWithTag("ObjetSante");
        objetAFaireApparaitre2 = GameObject.FindWithTag("ObjetPotion");
        Instantiate(objetAFaireApparaitre, endroit_a_apparaitre, rotationObjet);
        Instantiate(objetAFaireApparaitre2, endroit_a_apparaitre, rotationObjet);
    }

    void randomizePosition()
    {
        randomPositionX = Random.Range(-4, 8);
        randomPositionY = Random.Range(-4, 1);
        endroit_a_apparaitre = new Vector3(randomPositionX, randomPositionY, 0);
    }
}
