using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {
    [SerializeField] GameObject Bullet;
    [SerializeField] float fireRate = 1;
    [SerializeField] GameObject bulletEmitter;

    private GameObject fleche;
    private GameObject player;

    // Use this for initialization
    private float timerLastShot = 0;
    void Start()
    {
        fleche = GameObject.FindGameObjectWithTag("Direction");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        timerLastShot += Time.deltaTime;
        float currentPower = gameObject.transform.parent.gameObject.GetComponentInChildren<PowerBarDamage>().currentBarPower();
        if (timerLastShot > fireRate)
        {
            var fire1 = Input.GetAxis("Fire1");
            if (fire1 > 0 && currentPower >= Bullet.transform.GetComponent<ShotScript>().power)
            {
                //int power = GetComponent<ShotScript>().power;
                Bullet.GetComponent<MoveScript>().speed = fleche.transform.localScale.x * Bullet.GetComponent<MoveScript>().speedMutiplier;
                GameObject instanceOfBullet = Instantiate(Bullet, bulletEmitter.transform.position, fleche.transform.rotation);
                instanceOfBullet.GetComponent<SpellColision>().SetFriends(gameObject.transform.parent.gameObject);
                //Bullet.transform.rotation = fleche.transform.rotation;
                timerLastShot = 0;
                gameObject.transform.parent.gameObject.GetComponentInChildren<PowerBarDamage>().DicreasePower(Bullet.transform.GetComponent<ShotScript>().power);
            }
            
        }
    }
}
