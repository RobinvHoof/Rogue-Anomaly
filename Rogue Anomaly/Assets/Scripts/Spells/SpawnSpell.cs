using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpell : MonoBehaviour
{
    // Start is called before the first frame update
    

    [Header("Spell Data")]
    [SerializeField]
    public GameObject currentSpell;

    [Header("Mana Settings")]
    [SerializeField]
    float TotalMana = 100f;
    [SerializeField]
    float CurrentMana = 0f;
    [SerializeField]
    [Range(0,100)]
    float ManaRegenPerTick = 5f;
    [SerializeField]
    [Range(0f,1f)]
    float TimeDelay = 0.2f;
    [SerializeField]
    bool isRegenerating = false;
    float lastSpellCast = 0;
    [SerializeField]
    int ManaRegenDelay = 5;

    private void Start()
    {
        CurrentMana = TotalMana;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(currentSpell.GetComponent<BaseSpellEffect>().GetSpellCost() <= CurrentMana)
            {
                GameObject obj = Instantiate(currentSpell, transform.position, transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(transform.forward * 2, ForceMode.Impulse);
                CurrentMana -= currentSpell.GetComponent<BaseSpellEffect>().GetSpellCost();
                lastSpellCast = Time.time;
                Destroy(obj, 8f); //Acts as a failsafe
            }
        }
        CheckIfManaCanRegenerate();
    }


    void CheckIfManaCanRegenerate()
    {
        if(lastSpellCast + ManaRegenDelay <= Time.time && !isRegenerating && CurrentMana < TotalMana)
        {
            StartCoroutine(RegenerateMana());
        }
    }

    IEnumerator RegenerateMana()
    {
        isRegenerating = true;
        CurrentMana += ManaRegenPerTick;
        yield return new WaitForSeconds(TimeDelay);
        isRegenerating = false;
    }
}
