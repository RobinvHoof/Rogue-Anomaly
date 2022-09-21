using UnityEngine;

public class EnemyHealth : MonoBehaviour, IAttackable
{
    [SerializeField] public int maxHealth = 100;
    int hitPoints;
    public bool IsDead { get; private set; } = false;

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
        if (IsDead) return;
        IsDead = true;
        // Enable once animations are finished
        //GetComponent<Animator>().SetTrigger("die");
    }
}
