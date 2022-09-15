using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int hitPoints;

    void Start()
    {
        hitPoints = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;

        if (hitPoints <= 0)
        {
            GetComponent<PlayerDeathHandler>().HandleDeath();
        }
    }

    public void RestoreHealth(int healthAmount)
    {
        hitPoints = Mathf.Clamp(hitPoints + healthAmount, 0, maxHealth);
    }

    public int GetCurrentHitPoints()
    {
        return hitPoints;
    }
}
