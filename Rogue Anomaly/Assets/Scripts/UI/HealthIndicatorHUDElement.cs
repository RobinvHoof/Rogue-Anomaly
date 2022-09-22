using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicatorHUDElement : MonoBehaviour
{
    [SerializeField]
    Canvas baseCanvas;

    [SerializeField]
    PlayerHealth playerHealth;

    [SerializeField]
    int threshhold = 50;

    private RawImage bloodyBorder;

    private void Start() {
        GetComponent<RectTransform>().sizeDelta = baseCanvas.GetComponent<RectTransform>().sizeDelta;
        bloodyBorder = GetComponent<RawImage>();
    }

    public void Update() {
        if (playerHealth.currentHitPoints < threshhold)
            bloodyBorder.color = new Color(1, 1, 1, MapValue(playerHealth.currentHitPoints, 0, threshhold, 1, 0));        
        else
            bloodyBorder.color = new Color(1, 1, 1, 0);
    }

    private float MapValue(float value, float fromLow, float fromHigh, float toLow, float toHigh) 
    {
        return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
    }
}
