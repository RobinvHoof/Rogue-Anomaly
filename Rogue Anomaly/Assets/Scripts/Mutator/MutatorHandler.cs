using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class MutatorHandler : MonoBehaviour, IActionEvent
{
    [SerializeField] 
    public List<Mutator> AllMutators;

    [SerializeField] 
    public List<Mutator> ActiveMutators;

    [SerializeField] 
    public List<Mutator> AvailableMutators;

    // Depricated (Replaced by Timer System Integration)
    /*
    [SerializeField] 
    public int startupTime = 60;

    [SerializeField] 
    public int mutatorInBetweenTime = 60;
    */

    [SerializeField] 
    public FirstPersonController Player;

    [SerializeField] 
    public Camera PlayerCamera;
    void Start()
    {
        AvailableMutators = new List<Mutator>(AllMutators);
        
        // Depricated (Replaced by Timer System Integration) and compacted into code above
        /*
        if(AllMutators.Count > 0)
        {
            foreach (Mutator mutator in AllMutators)
            {
                AvailableMutators.Add(mutator);
            }

            //StartCoroutine(MutatorStartUpClock()); 
        }
        */
    }

    // Replaces Coroutine timer system
    public void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {
            case "timerTick":
                if (AvailableMutators.Count > 0)
                {
                    AddMutatorToActiveMutators(GetRandomMutator());
                }
                break;
        }
    }

    // Depricated (Replaced by Timer System Integration)
    /*
    IEnumerator MutatorStartUpClock()
    {
        yield return new WaitForSeconds(startupTime);

        StartCoroutine(MutatorClock());
    }
    IEnumerator MutatorClock()
    {   
        AddMutatorToActiveMutators(GetRandomMutator());
               
        yield return new WaitForSecondsRealtime(mutatorInBetweenTime);
        if(AvailableMutators.Count > 0)
        {
            StartCoroutine(MutatorClock());
        }
        
    }
    */

    // Method not used (Data can be aquired by accessing "AllMutators" directly. If needed, rewrite into Get property)
    /*
    public List<Mutator> GetAllMutators()
    {
        List<Mutator> mutators = null;
        
        foreach(Mutator mutator in AllMutators)
        {
            mutators.Add(mutator);           
        }
        return mutators;
    }
    */

    private void MutatorStatChange(Mutator mutator)
    {
        switch (mutator.Title)
        {
            case "IncreaseMoveButNoJump":
                Player.AddSpeedBoost(mutator.EffectAmountPositive);
                Player.ChangeJumpSpeed(0f);
                break;
            case "FovDecrease":
                PlayerCamera.fieldOfView = PlayerCamera.fieldOfView - mutator.EffectAmountNegative;
                break;
            case "InvertedControls":
                Player.ActivateInvertedControls();
                break;
            default:
                // code block
                break;
        }
    }

    /*  Method not used (Data can be aquired by accessing "ActiveMutators" directly. If needed, rewrite into Get property)
    public List<Mutator> GetAllActiveMutators()
    {
        List<Mutator> mutators = null;

        foreach (Mutator mutator in ActiveMutators)
        {
            mutators.Add(mutator);
        }

        return mutators;
    }
    */

    public Mutator GetRandomMutator()
    {
        if (AvailableMutators.Count == 0) // Failsafe check in case no mutators available
            return null;

        if (AvailableMutators.Count == 1)
            return GetMutatorFromAvailableMutators(0);
        else
            return GetMutatorFromAvailableMutators(Random.Range(0, AvailableMutators.Count - 1));
        
        // Compacted into code above
        /*
        int randomNumber = 0;
        if (AvailableMutators.Count != 1)
        {
            randomNumber = Random.Range(0, AvailableMutators.Count - 1);
        }

        return GetMutatorFromAvailableMutators(randomNumber);
        */
    }

    public void RemoveMutatorFromActiveMutators(int ID)
    {
        Mutator mutator = ActiveMutators.Find(x => x.MutatorID == ID);

        if (mutator != null)
            ActiveMutators.Remove(mutator);


        // Compacted into code above
        /*
        foreach(Mutator mutator in ActiveMutators)
        {
            if(mutator.MutatorID == ID)
            {
                ActiveMutators.Remove(mutator);
            }
        }
        */
    }

    public void RemoveMutatorFromAvailableMutators(int ID)
    {
        Mutator mutatorToRemove = AvailableMutators.Find(x => x.MutatorID == ID);
        AvailableMutators.Remove(mutatorToRemove);

        // Compacted into code above
        /*
        foreach (Mutator m in AvailableMutators)
        {
            if (m.MutatorID == ID)
            {
                mutatorToRemove = m;
                break;
            }
        }

        AvailableMutators.Remove(mutatorToRemove);
        */

    }

    public void AddMutatorToActiveMutators(Mutator mutatorToAdd)
    {
        
        if (mutatorToAdd == null)
            return;

        if (ActiveMutators.Find(x => x.MutatorID == mutatorToAdd.MutatorID) != null)
        {
            Debug.Log("mutator already active");
            return;
        }

        // Compacted into code above
        /*
        foreach (Mutator mutator in ActiveMutators)
        {
            if (mutator.MutatorID == mutatorToAdd.MutatorID)
            {
                Debug.Log("mutator already active");
                return;
            }
        }
        */

        ActiveMutators.Add(mutatorToAdd);
        RemoveMutatorFromAvailableMutators(mutatorToAdd.MutatorID);

        MutatorStatChange(mutatorToAdd);
    }


    public Mutator GetMutatorFromAvailableMutators(int index)
    {
        return AvailableMutators[index];

        // Compacted into code above
        /*
        Mutator mutator = null;

        mutator = AvailableMutators[index];


        return mutator;
        */
    }
    

    public bool CheckIfMutatorIsActive(string title)
    {
        return ActiveMutators.Find(x => x.Title == title) != null;
        
        // Compacted into code above
        /*
        bool isActive = false;

        foreach (Mutator m in ActiveMutators)
        {
            if(m.Title == title)
            {
                isActive = true;
                break;
            }
        }

        return isActive;
        */
    }

    
    void Update()
    {
        //Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(Player.transform.rotation.x, Player.transform.rotation.y, -180f), 1 * 2);
    }
}
