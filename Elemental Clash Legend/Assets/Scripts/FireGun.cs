using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject bulletEmitter;
    [SerializeField] GameObject fleche;

    bool active = false;
    bool fired = false;

    // Update is called once per frame
    void Update()
    {
        if (active && !fired)
        {
            if (Input.GetAxis("Fire1") > 0)
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Bullet.GetComponent<MoveScript>().speed = fleche.transform.localScale.x * Bullet.GetComponent<MoveScript>().speedMutiplier;
        Instantiate(Bullet, bulletEmitter.transform.position, fleche.transform.rotation);
        fired = true;
        MultiplayerEventManager.TriggerNextPhase();
    }

    public void Activate()
    {
        active = true;
        fired = false;
    }

    public void Deactivate()
    {
        active = false;
        fired = true;
    }
}
