using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {
    [SerializeField] GameObject Bullet;
    [SerializeField] float fireRate = 1;
    [SerializeField] GameObject bulletEmitter;
    // Use this for initialization
    private float timerLastShot = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerLastShot += Time.deltaTime;
        if (timerLastShot > fireRate)
        {
            var fire1 = Input.GetAxis("Jump");
            if (fire1 > 0)
            {
                Instantiate(Bullet/*, bulletEmitter.transform.position, bulletEmitter.transform.rotation*/);
                timerLastShot = 0;
            }
        }
    }
}
