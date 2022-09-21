using UnityEngine;

public class EnemyHealth : MonoBehaviour, IAttackable
{
    [SerializeField] public int maxHealth = 100;
    int hitPoints;
    bool isDead = false;
    bool IsDead => isDead;

    private void Start()
    {
        hitPoints = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        BroadcastMessage("OnDamageTaken");
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
