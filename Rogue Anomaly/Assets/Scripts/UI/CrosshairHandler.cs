using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairHandler : MonoBehaviour
{
    [SerializeField] 
    public Texture2D defaultCrosshair;
    

    private RawImage crosshairCanvas;

    void Start()
    {
        crosshairCanvas = GetComponent<RawImage>();
    }

    void Update()
    {
        //GameObject takeoverCrosshair = GetComponent<GunManager>().activeGun.crosshair;
        crosshairCanvas.texture = defaultCrosshair;
    }
}
