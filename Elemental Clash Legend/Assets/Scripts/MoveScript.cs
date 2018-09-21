using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    // Use this for initialization
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    //[SerializeField] GameObject Bullet;
    [SerializeField] float fireRate = 1;
    private Vector2 movement;
    private float timerLastShot = 0;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var fire1 = Input.GetAxis("Jump");
        timerLastShot += Time.deltaTime;
        if (timerLastShot > fireRate)
        {
            if (fire1 > 0)
            {
                movement = new Vector2(speed.x, speed.y);
                //GameObject newBullet = (GameObject)Instantiate(Bullet) as GameObject;
                //Instantiate(Bullet, bulletEmitter.transform.position = new Vector2(5,5), bulletEmitter.transform.rotation);
                //newBullet.transform.position = new Vector2(10, 10);
                timerLastShot = 0;
            }
        }
        
	}

}
