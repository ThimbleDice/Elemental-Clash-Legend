using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    // Use this for initialization
    public int damage = 1;
    public bool isEnemyShot = false;
    [SerializeField] GameObject Bullet;
    void Start () {
        Destroy(gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
        GameObject newBullet = (GameObject)Instantiate(Bullet) as GameObject;
        //Instantiate(Bullet, bulletEmitter.transform.position = new Vector2(5,5), bulletEmitter.transform.rotation);
        newBullet.transform.position = new Vector2(10, 10);
    }
}
