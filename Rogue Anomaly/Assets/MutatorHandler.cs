using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class MutatorHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Mutator> AllMutators;
    [SerializeField] List<Mutator> ActiveMutators;
    [SerializeField] List<Mutator> AvailableMutators;


    [SerializeField] FirstPersonController Player;
    [SerializeField] Camera PlayerCam;
    void Start()
    {
        foreach(Mutator m in AllMutators)
        {
            AvailableMutators.Add(m);
        }
        
        StartCoroutine(MutatorClock());
    }

    IEnumerator MutatorClock()
    {
        Debug.Log("add one");     
        AddMutatorToActiveMutators(GetRandomMutator());
               
        yield return new WaitForSecondsRealtime(10);
        if(AvailableMutators.Count > 0)
        {
            StartCoroutine(MutatorClock());
        }
        
    }

    public List<Mutator> GetAllMutators()
    {
        List<Mutator> mutators = null;
        
        foreach(Mutator m in AllMutators)
        {
            mutators.Add(m);           
        }
        return mutators;
    }

    private void MutatorStatChange(Mutator mutator)
    {
        switch (mutator.MutatorID)
        {
            case 0:
                Player.AddSpeedBoost(mutator.EffectAmountPositive);
                break;
            case 1:
                PlayerCam.fieldOfView = PlayerCam.fieldOfView - mutator.EffectAmountNegative;
                break;
            default:
                // code block
                break;
        }
    }

    public List<Mutator> GetAllActiveMutators()
    {
        List<Mutator> mutators = null;

        foreach (Mutator m in ActiveMutators)
        {
            mutators.Add(m);
        }

        return mutators;
    }

    public Mutator GetRandomMutator()
    {
        int randomNumber = 0;
        if (AvailableMutators.Count != 1)
        {
            randomNumber = Random.Range(0, AvailableMutators.Count - 1);
        }


        Debug.Log(randomNumber + " random number");
        return GetMutatorFromAvailableMutators(randomNumber);
    }

    public void RemoveMutatorFromActiveMutators(int ID)
    {
        foreach(Mutator m in ActiveMutators)
        {
            if(m.MutatorID == ID)
            {
                ActiveMutators.Remove(m);
            }
        }

    }

    public void RemoveMutatorFromAvailableMutators(int ID)
    {
        Mutator mutatorToRemove = null;
        foreach (Mutator m in AvailableMutators)
        {
            if (m.MutatorID == ID)
            {
                mutatorToRemove = m;
                break;
            }
        }

        AvailableMutators.Remove(mutatorToRemove);

    }

    public void AddMutatorToActiveMutators(Mutator mutatorToAdd)
    {
        Debug.Log(mutatorToAdd + " de");

        if(mutatorToAdd == null)
        {
            return;
        }
        foreach (Mutator m in ActiveMutators)
        {
            if (m.MutatorID == mutatorToAdd.MutatorID)
            {
                Debug.Log("mutator already active");
                return;
            }
        }

        ActiveMutators.Add(mutatorToAdd);
        RemoveMutatorFromAvailableMutators(mutatorToAdd.MutatorID);

        MutatorStatChange(mutatorToAdd);

    }

    public Mutator GetMutatorFromAvailableMutators(int index)
    {
        Mutator mutator = null;

        mutator = AvailableMutators[index];


        return mutator;
    }
    // Update is called once per frame
    public bool CheckIfMutatorIsActive(int ID)
    {
        bool isActive = false;

        foreach (Mutator m in ActiveMutators)
        {
            if(m.MutatorID == ID)
            {
                isActive = true;
                break;
            }
        }

        return isActive;
    }
    void Update()
    {
        //Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(Player.transform.rotation.x, Player.transform.rotation.y, -180f), 1 * 2);
    }
}
