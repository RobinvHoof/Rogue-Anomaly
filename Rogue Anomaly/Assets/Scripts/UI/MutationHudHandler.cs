using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MutationHudHandler : MonoBehaviour
{
    [SerializeField]
    public MutatorHandler mutatorHandler;

    [SerializeField]
    public RawImage lastMutationBorder;


    private TextMeshProUGUI textRenderer;

    void Start() 
    {
        textRenderer = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (mutatorHandler.ActiveMutators.Count == 0)
        {
            lastMutationBorder.enabled = false;
            textRenderer.enabled = false;
            return;
        }
        lastMutationBorder.enabled = true;
        textRenderer.enabled = true;

        Mutator lastMutator = mutatorHandler.ActiveMutators[mutatorHandler.ActiveMutators.Count - 1];
        textRenderer.SetText(lastMutator.Title);
    }
}
