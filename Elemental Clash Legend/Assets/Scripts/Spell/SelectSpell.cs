using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSpell : MonoBehaviour {

    [SerializeField] public GameObject[] spell;

    private FireGun fireGun;

    private void Start()
    {
        fireGun = gameObject.GetComponent<FireGun>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            fireGun.Bullet = spell[0];
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            fireGun.Bullet = spell[1];
        }
    }
}
