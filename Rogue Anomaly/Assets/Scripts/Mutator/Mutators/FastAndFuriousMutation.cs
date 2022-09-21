using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FastAndFuriousMutation : BaseMutation
{
    [SerializeField]
    public RigidbodyFirstPersonController FPSController;


    public FastAndFuriousMutation() : base("Fast and Furious", "Take a shot of energy and run those legs off! You get icreased movement speed") {}

    private Dictionary<string, float> playerIncreaseAmount;

    private void Start() 
    {
        playerIncreaseAmount = new();
    }
    
    public override void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {           
            case "startMutation":
                playerIncreaseAmount.Add("Forward", FPSController.movementSettings.ForwardSpeed);
                playerIncreaseAmount.Add("Backward", FPSController.movementSettings.BackwardSpeed);
                playerIncreaseAmount.Add("Strafe", FPSController.movementSettings.StrafeSpeed);

                FPSController.movementSettings.ForwardSpeed *= 2;
                FPSController.movementSettings.BackwardSpeed *= 2;
                FPSController.movementSettings.StrafeSpeed *= 2;
                break;

            case "stopMutation":
                FPSController.movementSettings.ForwardSpeed -= playerIncreaseAmount["Forward"];
                FPSController.movementSettings.BackwardSpeed -= playerIncreaseAmount["Backward"];
                FPSController.movementSettings.StrafeSpeed -= playerIncreaseAmount["Strafe"];
                break;
        }
    }
}
