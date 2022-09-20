using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairHandler : MonoBehaviour
{
    [SerializeField] Texture2D defaultCrosshair;
    
    private RawImage crosshairCanvas;

    void Start()
    {
        crosshairCanvas = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject takeoverCrosshair = GetComponent<GunManager>().activeGun.crosshair;
        crosshairCanvas.texture = defaultCrosshair;
    }
}
