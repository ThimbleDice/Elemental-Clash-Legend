using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpellColision : MonoBehaviour {

    [SerializeField] public float DestructionRadius = 1;
    [SerializeField] public float MapScale = 1.0f;
    [SerializeField] public int MaxHit = 1;

    private GameObject tilemapGameObject;
    private GameObject friends;
    private GameObject Enemy;
    private GameObject potion_sante;
    private GameObject potion_mana;
    private Tilemap tilemap;
    private int hitCount = 0;


    void Start()
    {
        tilemapGameObject = GameObject.FindGameObjectWithTag("MapSolid");
        
        tilemap = tilemapGameObject.GetComponent<Tilemap>();
    }

    public void SetFriends(GameObject friend)
    {
        friends = friend;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            destroyTerrain(collision);
            destroyObject();
        }
        if(collision.gameObject != friends)
        {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            Enemy.GetComponentInChildren<HealthBarDamage>().DicreaseHealth(GameObject.FindGameObjectWithTag("Effet").transform.GetComponent<ShotScript>().power);
            destroyObject();
        }
    }

    private void destroyTerrain(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        int centerCollision = collision.contactCount / 2;
        ContactPoint2D hit = collision.contacts[centerCollision];

        for (float x = -DestructionRadius; x < (DestructionRadius == 0 ? 1 : DestructionRadius); x++)
        {
            for (float y = -DestructionRadius; y < (DestructionRadius == 0 ? 1 : DestructionRadius); y++)
            {
                hitPosition.x = hit.point.x + (x * MapScale) - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y + (y * MapScale) - 0.01f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
    }

    private void destroyObject()
    {
        hitCount++;
        if (hitCount >= MaxHit)
            Destroy(gameObject);
    }
}
