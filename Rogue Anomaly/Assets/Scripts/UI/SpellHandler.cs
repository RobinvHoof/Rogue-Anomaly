using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject spellSystem;

    [SerializeField]
    public RawImage spellBorder;

    private RawImage iconRenderer;

    void Start()
    {
        iconRenderer = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject activeSpell = spellSystem.GetComponent<SpawnSpell>().currentSpell;

        if (activeSpell == null)
        {
            iconRenderer.enabled = false;
            spellBorder.enabled = false;
            return;
        }

        iconRenderer.enabled = true;
        spellBorder.enabled = true;
        iconRenderer.texture = activeSpell.GetComponent<BaseSpellEffect>().SpellIcon;
    }
}
