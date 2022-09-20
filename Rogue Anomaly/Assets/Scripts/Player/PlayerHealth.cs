using UnityEngine;

public class PlayerHealth : MonoBehaviour, IAttackable
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] float healthRegenerationRate = 1;
    [SerializeField] float regenerationDelay = 1;
    int hitPoints;
    float regenBuffer;
    float lastHitTime = -1;

    void Start()
    {
        hitPoints = maxHealth;
    }

    void Update()
    {
        if (lastHitTime >= 0 && Time.time - lastHitTime >= regenerationDelay)
        {
            RegenerateHealth();
        }
    }

    void RegenerateHealth()
    {
        regenBuffer += healthRegenerationRate * Time.deltaTime;
        int regenAmount = Mathf.FloorToInt(regenBuffer);
        regenBuffer -= regenAmount;
        if (regenAmount > 0) RestoreHealth(regenAmount);
    }

    public void TakeDamage(int damageAmount)
    {   
        hitPoints -= damageAmount;
        Debug.Log("Current health is " + hitPoints);
        lastHitTime = Time.time;
        regenBuffer = 0;

        if (hitPoints <= 0)
        {
            GetComponent<PlayerDeathHandler>().HandleDeath();
        }
    }

    public void RestoreHealth(int healthAmount)
    {
        hitPoints = Mathf.Clamp(hitPoints + healthAmount, 0, maxHealth);

        if(hitPoints == maxHealth)
         {
            lastHitTime = -1;
            regenBuffer = 0;
         }
    }

    public int GetCurrentHitPoints()
    {
        return hitPoints;
    }
}
