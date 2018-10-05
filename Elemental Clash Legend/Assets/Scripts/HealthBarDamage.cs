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
        DicreaseHealth();
    }

    private void Awake()
    {
        healthBar = GetComponent<SimpleHealthBar>();
    }

    public void IncreaseHealth()
    {
            currentHealth += damage;
            healthBar.UpdateBar(currentHealth, maxHealth);

            if (currentHealth <= mediumHealth)
            {
                healthBar.UpdateColor(Color.yellow);
            }

            if (currentHealth <= criticalHealth)
            {
                healthBar.UpdateColor(Color.red);
            }

            if (currentHealth >= criticalHealth)
            {
                healthBar.UpdateColor(Color.green);
            }
    }


    private void DicreaseHealth()
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
