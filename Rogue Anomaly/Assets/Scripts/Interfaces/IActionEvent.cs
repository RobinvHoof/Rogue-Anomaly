using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionEvent
{
    public void TriggerEvent(GameObject source, string eventName = "default", params object[] arguments);
}