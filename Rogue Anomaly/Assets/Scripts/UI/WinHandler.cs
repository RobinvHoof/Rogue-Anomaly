using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WinHandler : MonoBehaviour
{
    [SerializeField]
    Canvas winCanvas;

    [SerializeField]
    Canvas playCanvas;

    [SerializeField]
    FirstPersonController FPController;

    [SerializeField]
    Camera externalCamera;

 
    private void Start()
    {
        winCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        winCanvas.enabled = true;
        playCanvas.enabled = false;
        FPController.gameObject.SetActive(false);
        externalCamera.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
