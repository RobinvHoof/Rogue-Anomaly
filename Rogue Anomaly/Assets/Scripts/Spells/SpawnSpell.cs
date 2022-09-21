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
    public float SpellFireDelay = 1f;

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

<<<<<<< Updated upstream

    private float lastSpellCast = 0;
    private FragileVampirismMutation fragileVampirismMutation;
=======
    private string lastSpell;
    private float lastSpellCastTime = 0;
    private bool isCasting = false;
>>>>>>> Stashed changes

    private void Start()
    {
        CurrentMana = TotalMana;
<<<<<<< Updated upstream
        fragileVampirismMutation = FindObjectOfType<FragileVampirismMutation>();
=======
        lastSpell = null;
>>>>>>> Stashed changes
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(currentSpell.GetComponent<BaseSpellEffect>().GetSpellCost() <= CurrentMana && isCasting == false)
            {
<<<<<<< Updated upstream
                GameObject obj = Instantiate(currentSpell,transform.position,transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(transform.forward * 2, ForceMode.Impulse);
                
                // Trigger Fragile Vampirism mutation
                fragileVampirismMutation.TriggerEvent(this.gameObject, "shotFired");

                CurrentMana -= currentSpell.GetComponent<BaseSpellEffect>().GetSpellCost();
                lastSpellCast = Time.time;
                Destroy(obj, 8f);
=======
                StartCoroutine(CastSpell());
>>>>>>> Stashed changes
            }
        }
        CheckIfManaCanRegenerate();

        if (lastSpell != currentSpell.name)
        {
            lastSpell = currentSpell.name;
            SpellFireDelay = currentSpell.GetComponent<BaseSpellEffect>().GetSpellFireRate();
        }
    }

    IEnumerator CastSpell()
    {
        isCasting = true;
        GameObject obj = Instantiate(currentSpell, transform.position, transform.rotation);
        obj.GetComponent<Rigidbody>().AddForce(transform.forward * 2, ForceMode.Impulse);
        CurrentMana -= currentSpell.GetComponent<BaseSpellEffect>().GetSpellCost();
        lastSpellCastTime = Time.time;
        yield return new WaitForSeconds(SpellFireDelay);
        Destroy(obj, 8f);
        isCasting = false;
    }

    // Check if mana can be regenerated
    void CheckIfManaCanRegenerate()
    {
        if(lastSpellCastTime + ManaRegenDelay <= Time.time && !isRegenerating && CurrentMana < TotalMana)
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
