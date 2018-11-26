using UnityEngine;

public class PowerBarDamage : MonoBehaviour
{
    private SimpleHealthBar powerBar;
    public float currentPower = 100;
    float maxPower = 100;
    float mediumPower = 50;
    float criticalPower = 25;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
                
    }

    private void Awake()
    {
        powerBar = GetComponentInChildren<SimpleHealthBar>();
    }

    public void IncreasePower()
    {
            currentPower += 5;
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

    public void DecreasePower(int power)
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

    public float currentBarPower()
    {
        return currentPower;
    }
}
