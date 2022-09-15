using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    FirstPersonController playerController;

    private void Start() {
        gameOverCanvas.enabled = false;
        playerController = GetComponent<FirstPersonController>();
    }

    public void HandleDeath()
    {
        playerController.enabled = false;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
