using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpell : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    [Header("Spell Data")]
    public GameObject currentSpell;

    [SerializeField]
    [Header("Mana Settings")]
    public float TotalMana = 100f;

    [SerializeField]
    public float CurrentMana = 0f;

    [SerializeField]
    [Range(0,100)]
    public float ManaRegenPerTick = 5f;

    [SerializeField]
    [Range(0f,1f)]
    public float TimeDelay = 0.2f;

    [SerializeField]
    public bool isRegenerating = false;

    [SerializeField]
    public int ManaRegenDelay = 5;


    private float lastSpellCast = 0;

    private void Start()
    {
        CurrentMana = TotalMana;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(currentSpell.GetComponent<BaseSpellEffect>().GetSpellCost() <= CurrentMana)
            {
                GameObject obj = Instantiate(currentSpell,transform.position,transform.rotation,transform);
                obj.GetComponent<Rigidbody>().AddForce(transform.forward * 2, ForceMode.Impulse);
                CurrentMana -= currentSpell.GetComponent<BaseSpellEffect>().GetSpellCost();
                lastSpellCast = Time.time;
                Destroy(obj, 8f); //Acts as a failsafe
            }
        }
        CheckIfManaCanRegenerate();
    }

    // Check if mana can be regenerated
    void CheckIfManaCanRegenerate()
    {
        if(lastSpellCast + ManaRegenDelay <= Time.time && !isRegenerating && CurrentMana < TotalMana)
        {
            StartCoroutine(RegenerateMana());
        }
    }

    // Regenerate mana over time
    IEnumerator RegenerateMana()
    {
        isRegenerating = true;
        CurrentMana += ManaRegenPerTick;
        yield return new WaitForSeconds(TimeDelay);
        isRegenerating = false;
    }
}
