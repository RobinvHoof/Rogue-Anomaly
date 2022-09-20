using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerHandler : MonoBehaviour, IActionEvent
{
    // Check passed time and tick time forward on HUD element
    public void TriggerEvent(GameObject source, string eventName, params object[] parameters)
    {
        switch(eventName)
        {
            case "timerTick":
                TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
                textMesh.SetText(source.GetComponent<Timer>().elapsedTimeString);
                break;
        }
    }
}
