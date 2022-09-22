using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class MutationManager : MonoBehaviour, IActionEvent
{
    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public AudioClip newMutationSound;
    
    
    public List<BaseMutation> availableMutations;
    public List<BaseMutation> activeMutations;


    public void Start() 
    {
        availableMutations = new List<BaseMutation>(GetComponentsInChildren<BaseMutation>());
    }

    public void Update() 
    {
        foreach(BaseMutation mutation in activeMutations)
        {
            mutation.TriggerEvent(this.gameObject, "mutationTick");
        }    
    }

    // Triggers any event send to the script
    //   timerTick: (Ticks on timer event)
    //     Parameter[0] : Ingame time
    public void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {
            case "timerTick":
                if (availableMutations.Count > 0 && (System.Convert.ToInt32(parameters[0]) != 0))
                {
                    ActivateMutation(GetRandomMutation());
                
                    audioSource.PlayOneShot(newMutationSound);
                }
                break;
        }
    }

    public bool IsMutationActive(BaseMutation mutation)
    {
        return (activeMutations.Find(x => x.Title == mutation.Title) != null);
    }

    private void ActivateMutation(BaseMutation mutation)
    {
        if (availableMutations.Find(x => x.Title == mutation.Title) == null)
            return;

        availableMutations.Remove(mutation);
        activeMutations.Add(mutation);

        mutation.TriggerEvent(this.gameObject, "startMutation");
    }

    private void DeactiveMutation(BaseMutation mutation)
    {
        if (activeMutations.Find(x => x.Title == mutation.Title) == null)
            return;
        
        activeMutations.Remove(mutation);
        availableMutations.Add(mutation);

        mutation.TriggerEvent(this.gameObject, "stopMutation");
    }

    private BaseMutation GetRandomMutation()
    {
        if (availableMutations.Count == 0)
            return null;

        return availableMutations[Random.Range(0, availableMutations.Count)];
    }
}