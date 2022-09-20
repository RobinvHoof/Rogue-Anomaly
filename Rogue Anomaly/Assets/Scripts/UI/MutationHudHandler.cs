using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MutationHudHandler : MonoBehaviour
{
    [SerializeField]
    public MutationManager mutationManager;

    [SerializeField]
    public RawImage lastMutationBorder;


    private TextMeshProUGUI textRenderer;

    void Start() 
    {
        textRenderer = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (mutationManager.activeMutations.Count == 0)
        {
            lastMutationBorder.enabled = false;
            textRenderer.enabled = false;
            return;
        }
        lastMutationBorder.enabled = true;
        textRenderer.enabled = true;

        BaseMutation lastMutation = mutationManager.activeMutations[mutationManager.activeMutations.Count - 1];
        textRenderer.SetText(lastMutation.Title);
    }
}
