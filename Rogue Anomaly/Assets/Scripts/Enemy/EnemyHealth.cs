using UnityEngine;

public class EnemyHealth : MonoBehaviour, IAttackable
{
    public int maxHealth = 100;

    [SerializeField]
    public int hitPoints;
    public bool IsDead { get; private set; } = false;
    private FragileVampirismMutation fragileVampirismMutation;

    private void Start()
    {
        hitPoints = maxHealth;
        fragileVampirismMutation = FindObjectOfType<FragileVampirismMutation>();
    }

    public void TakeDamage(int damageAmount)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damageAmount;

        // Trigger Fragile Vampirism Mutation
        fragileVampirismMutation.TriggerEvent(this.gameObject, "hitShot");

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
