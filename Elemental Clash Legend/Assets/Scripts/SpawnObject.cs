using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    [SerializeField] GameObject objetAFaireApparaitre;
    //Vector3 endroit_a_apparaitre(0,0,0);
    // Use this for initialization
    void Start () {
        objetAFaireApparaitre = GameObject.FindWithTag("Objet");
        objetAFaireApparaitre.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            objetAFaireApparaitre.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(objetAFaireApparaitre, objetAFaireApparaitre.transform.position, objetAFaireApparaitre.transform.rotation);
        }
    }
}
