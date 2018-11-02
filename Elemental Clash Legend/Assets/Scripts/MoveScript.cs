using UnityEngine;

/// <summary>
/// Déplace l'objet
/// </summary>
public class MoveScript : MonoBehaviour
{
    // 1 - Designer variables
    protected Rigidbody2D rigidbody2D;
    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    [HideInInspector]
    public float speed = 1.0f;
    public float speedMutiplier = 1.0f;
    private GameObject effet;
    


    private Vector2 movement;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
    }
    void Update()
    {
    }

    void FixedUpdate()
    {
        //transform.Translate(new Vector2(1*speed,0));
        rigidbody2D.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
    }
}
