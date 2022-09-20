using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseMutation : MonoBehaviour, IActionEvent
{    
    public string Title {get; private set;}
    public string Description {get; private set;}

    // To supply the BaseMutation with the data needed (Title and Description), make an empty constructor in your Mutation that passes the required information on to the BaseMutation;
    /* Example Code:
        public TestMutation() : base("Test Mutation", "This mutation is just a test to explain the concept!") {}
    */
    public BaseMutation(string title, string description)
    {
        Title = title;
        Description = description;
    }

    // This method is the main method to do any actions using Mutations.
    // The MutationManager has three default event names built in that are fired in three different situations:
    //   - startMutation : Gets triggered when a mutation is first activated
    //   - stopMutation: Gets triggered when a mutation is removed as active mutation
    //   - tickMutation: Gets triggered every tick if the mutation is activated in the manager
    //
    // Furthermore, custom events names can be made depending on the situation and triggered from anywhere in the project.
    /* Example code:
        public void TriggerEvent(GameObject source, string eventName, params object[] parameters)
        {
            switch(eventName)
            {
                case "startMutation":
                    // Do something
                    break;

                case "tickMutation":
                    // Do something
                    break;

                case "stopMutation":
                    // Do something
                    break;
            }
        }
    */
    public abstract void TriggerEvent(GameObject source, string eventName, params object[] parameters);
}
