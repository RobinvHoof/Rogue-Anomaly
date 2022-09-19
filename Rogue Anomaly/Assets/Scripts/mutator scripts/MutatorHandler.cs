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
    [SerializeField] int startupTime = 60;
    [SerializeField] int mutatorInBetweenTime = 60;

    [SerializeField] FirstPersonController Player;
    [SerializeField] Camera PlayerCam;
    void Start()
    {
        if(AllMutators.Count > 0)
        {
            foreach (Mutator m in AllMutators)
            {
                AvailableMutators.Add(m);
            }

            StartCoroutine(MutatorStartUpClock());
        }
        
    }
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
        switch (mutator.Title)
        {
            case "IncreaseMoveButNoJump":
                Player.AddSpeedBoost(mutator.EffectAmountPositive);
                Player.ChangeJumpSpeed(0f);
                break;
            case "FovDecrease":
                PlayerCam.fieldOfView = PlayerCam.fieldOfView - mutator.EffectAmountNegative;
                break;
            case "InvertedControls":
                Player.ActivateInvertedControls();
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
    public bool CheckIfMutatorIsActive(string title)
    {
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
    }
    void Update()
    {
        //Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, Quaternion.Euler(Player.transform.rotation.x, Player.transform.rotation.y, -180f), 1 * 2);
    }
}
