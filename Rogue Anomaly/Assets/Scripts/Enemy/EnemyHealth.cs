using UnityEngine;

public class EnemyHealth : MonoBehaviour, IAttackable
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int hitPoints;
    bool isDead = false;
    public bool IsDead => isDead;

    private FragileVampirismMutation fragileVampirismMutation;

    private void Start()
    {
        hitPoints = maxHealth;
        fragileVampirismMutation = FindObjectOfType<FragileVampirismMutation>();
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;

        // Trigger Fragile Vampirism Mutation
        fragileVampirismMutation.TriggerEvent(this.gameObject, "hitShot");

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
