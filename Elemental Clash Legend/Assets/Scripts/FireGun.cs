using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {
    [SerializeField] public GameObject Bullet;
    [SerializeField] GameObject bulletEmitter;
    [SerializeField] GameObject fleche;
    [SerializeField] GameObject player;

    bool active = false;
    bool fired = false;

    // Update is called once per frame
    void Update()
    {
        if (active && !fired)
        {
            if (Input.GetAxis("Fire1") > 0)
            {
                if (player.GetComponentInChildren<PowerBarDamage>().currentBarPower() >= Bullet.transform.GetComponent<ShotScript>().power)
                {
                    Fire();
                }
            }
        }
    }

    private void Fire()
    {
        Bullet.GetComponent<MoveScript>().speed = fleche.transform.localScale.x * Bullet.GetComponent<MoveScript>().speedMutiplier;
        GameObject instanceOfBullet = Instantiate(Bullet, bulletEmitter.transform.position, fleche.transform.rotation);
        instanceOfBullet.GetComponent<SpellColision>().SetFriends(player);
        player.gameObject.GetComponentInChildren<PowerBarDamage>().DecreasePower(Bullet.transform.GetComponent<ShotScript>().power);
        fired = true;
        AudioForCharacter.CastASpell();
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
