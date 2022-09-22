using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IAttackable
{
    public int maxHealth = 100;
    public int hitPoints { get; private set; }
    public bool IsDead { get; private set; } = false;
    private FragileVampirismMutation fragileVampirismMutation;

    private void Start()
    {
        hitPoints = maxHealth;
        fragileVampirismMutation = FindObjectOfType<FragileVampirismMutation>();
    }

    public void TakeDamage(int damageAmount)
    {
        //BroadcastMessage("OnDamageTaken");
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

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
        if (GetComponent<Rigidbody>() != null) GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    
        // Trigger death animition when present
        if (GetComponent<Animator>() != null) GetComponent<Animator>().SetTrigger("die");

        // Determine type of enemy AI script, and disable necessary scripts
        if (GetComponent<EnemyAI_Range>() != null)
        {
            GetComponent<EnemyAI_Range>().enabled = false;
            EnemyWeapon[] weaponScripts = GetComponentsInChildren<EnemyWeapon>();
            foreach (EnemyWeapon script in weaponScripts) script.enabled = false;
        }
        else if (GetComponent<EnemyAI>() != null)
        {
            GetComponent<EnemyAI>().enabled = false;
            Destroy(GetComponent<EnemyAI>());
        }
        else if (GetComponent<EnemyAI_Boss>() != null)
        {
            GetComponent<EnemyAI_Boss>().enabled = false;
            EnemyWeapon[] weaponScripts = GetComponentsInChildren<EnemyWeapon>();
            foreach (EnemyWeapon script in weaponScripts) script.enabled = false;
            Destroy(gameObject);
        }
    }
}
