using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestruction : MonoBehaviour {

    [SerializeField] float DestructionRadius = 0;
    public GameObject tilemapGameObject;

    Tilemap tilemap;

    // Use this for initialization
    void Start () {
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            for (float x = (gameObject.transform.position.x - (DestructionRadius)); x < (gameObject.transform.position.x + (DestructionRadius)); x++)
            {
                for (float y = (gameObject.transform.position.y - (DestructionRadius)); y < (gameObject.transform.position.y + (DestructionRadius)); y++)
                {
                    tilemap.SetTile(tilemap.WorldToCell(new Vector3(x,y)), null);
                }
            }
        }
    }
}
