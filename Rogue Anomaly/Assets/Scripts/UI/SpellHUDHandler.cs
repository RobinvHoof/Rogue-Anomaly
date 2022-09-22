using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellHUDHandler : MonoBehaviour
{
    [SerializeField]
    public SpawnSpell spellSystem;

    [SerializeField]
    public RawImage spellBorder;

    [SerializeField]
    public GameObject manaBar;

    private RawImage iconRenderer;

    void Start()
    {
        iconRenderer = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject activeSpell = spellSystem.currentSpell;

        if (activeSpell == null)
        {
            iconRenderer.enabled = false;
            spellBorder.enabled = false;
            manaBar.SetActive(false);
            return;
        }

        iconRenderer.enabled = true;
        spellBorder.enabled = true;
        manaBar.SetActive(true);
        iconRenderer.texture = activeSpell.GetComponent<BaseSpellEffect>().SpellIcon;

        Slider manaSlider = manaBar.GetComponent<Slider>();
        
        manaSlider.value = MapValue(spellSystem.CurrentMana, 0, spellSystem.TotalMana, 0, 1);
    }

    private float MapValue(float value, float fromLow, float fromHigh, float toLow, float toHigh) 
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
}
