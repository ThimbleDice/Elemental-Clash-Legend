using UnityEngine;

public class PowerBarDamage : MonoBehaviour
{
    public SimpleHealthBar powerBar;
    int power = 10;
    float currentPower = 100;
    float maxPower = 100;
    float mediumPower = 50;
    float criticalPower = 25;

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update ()
    {
        DicreasePower();
    }

    private void Awake()
    {
        powerBar = GetComponent<SimpleHealthBar>();
    }

    public void IncreasePower()
    {
            currentPower += power;
            powerBar.UpdateBar(currentPower, maxPower);

            if (currentPower <= mediumPower)
            {
                powerBar.UpdateColor(Color.cyan);
            }

            if (currentPower <= criticalPower)
            {
                powerBar.UpdateColor(Color.white);
            }

             if (currentPower >= mediumPower)
             {
                 powerBar.UpdateColor(Color.blue);
             }
    }

    private void DicreasePower()
    {
        if (Input.GetKeyDown("down"))
        {
            currentPower -= power;
            powerBar.UpdateBar(currentPower, maxPower);

            if (currentPower <= mediumPower)
            {
                powerBar.UpdateColor(Color.cyan);
            }

            if (currentPower <= criticalPower)
            {
                powerBar.UpdateColor(Color.white);
            }
        }
    }
}
