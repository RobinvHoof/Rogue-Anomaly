using UnityEngine;

public class PlayerHealth : MonoBehaviour, IAttackable
{
    [SerializeField] 
    public int maxHealth = 100;

    [SerializeField] 
    public float healthRegenerationRate = 1;

    [SerializeField] 
    public float regenerationDelay = 1;

    public int currentHitPoints {   // New (Get property instead of method)
        get {
            return hitPoints;
        }
    }


    private int hitPoints;
    private float regenBuffer;
    private float lastHitTime = -1;

    private LuckyBastardMutation luckyBastardMutation;
    void Start()
    {
        hitPoints = maxHealth;
        luckyBastardMutation = FindObjectOfType<LuckyBastardMutation>();
    }

    void Update()
    {
        if (lastHitTime >= 0 && Time.time - lastHitTime >= regenerationDelay)
        {
            RegenerateHealth();
        }
    }

    // Regenerate health if not taken damage in x amount of time
    void RegenerateHealth()
    {
        regenBuffer += healthRegenerationRate * Time.deltaTime;
        int regenAmount = Mathf.FloorToInt(regenBuffer);
        regenBuffer -= regenAmount;
        if (regenAmount > 0) RestoreHealth(regenAmount);
    }

    // Take damage
    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;
        lastHitTime = Time.time;
        regenBuffer = 0;

        // Trigger luckyBastard Mutation
        luckyBastardMutation.TriggerEvent(this.gameObject, "playerHit", damageAmount);

        if (hitPoints <= 0)
        {
            GetComponent<PlayerDeathHandler>().HandleDeath();
        }

        Debug.Log(hitPoints);
    }

    // Heal x amount, capped at maxHealth
    public void RestoreHealth(int healthAmount)
    {
        hitPoints = Mathf.Clamp(hitPoints + healthAmount, 0, maxHealth);

        if(hitPoints == maxHealth)
         {
            lastHitTime = -1;
            regenBuffer = 0;
         }
    }

    // Replaced by Get property "currentHitPoints"
    /*
    public int GetcurrentHitPoints() 
    {
        return hitPoints;
    }
    */
}
