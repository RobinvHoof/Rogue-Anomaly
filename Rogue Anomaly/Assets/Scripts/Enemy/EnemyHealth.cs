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

        // Trigger death animition when present
        if (GetComponent<Animator>() != null) GetComponent<Animator>().SetTrigger("die");

        // If ranged enemy, disable relevant scripts
        if (GetComponent<EnemyAI_Range>() != null)
        {
            GetComponent<EnemyAI_Range>().enabled = false;
            EnemyWeapon[] weaponScripts = GetComponentsInChildren<EnemyWeapon>();
            foreach (EnemyWeapon script in weaponScripts) script.enabled = false;
        }
    }
}
