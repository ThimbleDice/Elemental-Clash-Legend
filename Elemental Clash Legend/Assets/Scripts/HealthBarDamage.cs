using UnityEngine;

public class HealthBarDamage : MonoBehaviour
{
   public SimpleHealthBar healthBar;
    int damage = 10;
    float currentHealth = 100;
    float maxHealth = 100;
    float mediumHealth = 50;
    float criticalHealth = 25;

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update ()
    {
        TakeDamage();
    }

    private void Awake()
    {
        healthBar = GetComponent<SimpleHealthBar>();
    }

    private void TakeDamage()
    {   
        if (Input.GetKeyDown("up"))
        {
            currentHealth -= damage;
            healthBar.UpdateBar(currentHealth, maxHealth);

            if (currentHealth <= mediumHealth)
            {
                healthBar.UpdateColor(Color.yellow);
            }

            if (currentHealth <= criticalHealth)
            {
               healthBar.UpdateColor(Color.red);
            }
        }
    }
}
