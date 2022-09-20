using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Mutator", menuName = "Mutator")]
public class Mutator : ScriptableObject
{

    public int MutatorID;

    public string Title;

    public string Description;

    public float EffectAmountPositive;

    public float EffectAmountNegative;

    public int TierLevel;

}
