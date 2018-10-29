using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestruction : MonoBehaviour {

    [SerializeField] public float DestructionRadius = 1;
    [SerializeField] public float MapScale = 1.0f;
    [SerializeField] public int MaxHit = 1;

    private GameObject tilemapGameObject;
    private Tilemap tilemap;
    private int hitCount = 0;

    void Start () {
        tilemapGameObject = GameObject.FindGameObjectWithTag("MapSolid");
        tilemap = tilemapGameObject.GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        int centerCollision = collision.contactCount/2;
        ContactPoint2D hit = collision.contacts[centerCollision];
        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            for (float x = -DestructionRadius; x < (DestructionRadius == 0 ? 1 : DestructionRadius); x++)
            {
                for (float y = -DestructionRadius; y < (DestructionRadius == 0 ? 1 : DestructionRadius); y++)
                {
                    hitPosition.x = hit.point.x + (x * MapScale) - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y + (y * MapScale) - 0.01f * hit.normal.y;
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                }
            }
            destroyObject();
        }

    }

    private void destroyObject()
    {
        hitCount++;
        if (hitCount >= MaxHit)
            Destroy(gameObject);
    }
}