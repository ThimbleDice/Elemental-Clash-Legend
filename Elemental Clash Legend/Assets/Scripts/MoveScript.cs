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
    private GameObject effet;
    


    private Vector2 movement;

    private void Awake()
    {
        //rigidbody2D = GetComponent<Rigidbody2D>();
        effet = GameObject.FindGameObjectWithTag("Effet");
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

        //rigidbody2D.velocity = transform.right * speed;
        effet.transform.Translate(transform.right);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
    }
}
