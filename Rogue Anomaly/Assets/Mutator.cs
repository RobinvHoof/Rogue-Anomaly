using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Mutator", menuName = "Mutator")]
public class Mutator : ScriptableObject
{

    public int MutatorID;

    public string Title;

    public string Description;

    public float EffectAmount;

}
