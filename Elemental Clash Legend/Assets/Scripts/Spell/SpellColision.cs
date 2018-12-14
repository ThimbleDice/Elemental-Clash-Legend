using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpellColision : MonoBehaviour {

    [SerializeField] public float DestructionRadius = 1;
    [SerializeField] public float MapScale = 1.0f;
    [SerializeField] public int MaxHit = 1;

    private GameObject tilemapGameObject;
    private GameObject friend;
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

    public void SetFriends(GameObject newFriend)
    {
        friend = newFriend;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int centerCollision = collision.contactCount / 2;
        ContactPoint2D hit = collision.contacts[centerCollision];
        int dmg = gameObject.GetComponent<ShotScript>().health;
        if ((tilemap != null && tilemapGameObject == collision.gameObject) || collision.gameObject.tag == "Enemy")
        {
            destroyTerrain(hit);
            ExplosionDamage(new Vector3(hit.point.x, hit.point.y), DestructionRadius * MapScale, dmg);
            destroyObject();
        }
    }

    void ExplosionDamage(Vector3 center, float radius, int dmg)
    {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < gameManager.players.Length; i++)
        {
            if (Vector3.Distance(gameManager.players[i].transform.position, center) <= radius)
            {
                gameManager.players[i].GetComponentInChildren<HealthBarDamage>().DicreaseHealth(dmg);
            }
        }
    }

    private void destroyTerrain(ContactPoint2D hit)
    {
        Vector3 hitPosition = Vector3.zero;

        for (float x = -DestructionRadius; x < (DestructionRadius == 0 ? 1 : DestructionRadius); x++)
        {
            for (float y = -DestructionRadius; y < (DestructionRadius == 0 ? 1 : DestructionRadius); y++)
            {
                hitPosition.x = hit.point.x + (x * MapScale) - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y + (y * MapScale) - 0.01f * hit.normal.y;
                if (Vector3.Distance(hitPosition, new Vector3(hit.point.x, hit.point.y)) <= DestructionRadius * MapScale)
                {
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                }
            }
        }
    }

    private void destroyObject()
    {
        MultiplayerEventManager.TriggerSpellEnd();
        hitCount++;
        if (hitCount >= MaxHit)
            Destroy(gameObject);
    }
}
