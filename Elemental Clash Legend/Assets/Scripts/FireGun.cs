using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {
    [SerializeField] GameObject Bullet;
    [SerializeField] float fireRate = 1;
    [SerializeField] GameObject bulletEmitter;

    private GameObject fleche;

    // Use this for initialization
    private float timerLastShot = 0;
    void Start()
    {
        fleche = GameObject.FindGameObjectWithTag("Direction");

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        timerLastShot += Time.deltaTime;
        if (timerLastShot > fireRate)
        {
            var fire1 = Input.GetAxis("Fire1");
            if (fire1 > 0)
            {
                Bullet.GetComponent<MoveScript>().speed = fleche.transform.localScale.x * Bullet.GetComponent<MoveScript>().speedMutiplier;
                Instantiate(Bullet, bulletEmitter.transform.position, fleche.transform.rotation);
                
                //Bullet.transform.rotation = fleche.transform.rotation;
                timerLastShot = 0;
            }
        }
    }
}
