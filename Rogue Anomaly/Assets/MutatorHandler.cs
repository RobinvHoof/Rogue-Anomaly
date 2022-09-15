using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MutatorHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] List<Mutator> AllMutators;
    [SerializeField] List<Mutator> ActiveMutators;
    [SerializeField] List<Mutator> AvailableMutators;

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

    }

    public Mutator GetMutatorFromAvailableMutators(int index)
    {
        Mutator mutator = null;

        mutator = AvailableMutators[index];


        return mutator;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
