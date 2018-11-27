using UnityEngine;

public class HealthBarDamage : MonoBehaviour
{
    private SimpleHealthBar healthBar;
    int health = 10;
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
        
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<SimpleHealthBar>();
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);

        if (currentHealth <= mediumHealth)
        {
            healthBar.UpdateColor(Color.yellow);
        }

        if (currentHealth <= criticalHealth)
        {
            healthBar.UpdateColor(Color.red);
        }

        if (currentHealth >= mediumHealth)
        {
            healthBar.UpdateColor(Color.green);
        }
    }

    public void DicreaseHealth(int healt)
    {   
        //if (Input.GetKeyDown("up"))
        //{
            currentHealth -= health;
            healthBar.UpdateBar(currentHealth, maxHealth);

            if (currentHealth <= mediumHealth)
            {
                healthBar.UpdateColor(Color.yellow);
            }

            if (currentHealth <= criticalHealth)
            {
               healthBar.UpdateColor(Color.red);
            }
        //}
    }
}
