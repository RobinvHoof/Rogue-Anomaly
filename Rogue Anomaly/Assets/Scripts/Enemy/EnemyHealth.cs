using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int hitPoints;
    bool isDead = false;
    bool IsDead => isDead;

    private void Start()
    {
        hitPoints = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        // Enable once animations are finished
        //GetComponent<Animator>().SetTrigger("die");
    }
}
