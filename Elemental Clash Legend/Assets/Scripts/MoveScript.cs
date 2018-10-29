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
    public float speed = 1.0f;

    
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
        // Application du mouvement
        
        rigidbody2D.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
    }
}
