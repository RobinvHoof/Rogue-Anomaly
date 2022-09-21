using UnityEngine;

public class EnemyHealth : MonoBehaviour, IAttackable
{
    [SerializeField] 
    public float maxHealth = 100;


    public float hitPoints;
    private bool isDead = false;
    private bool IsDead => isDead;

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

    // Kill unit
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        // Enable once animations are finished
        //GetComponent<Animator>().SetTrigger("die");
    }
}
