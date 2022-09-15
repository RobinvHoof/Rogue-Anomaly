using UnityEngine;
using StandardAssets;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    FPSController playerController;

    private void Start() {
        gameOverCanvas.enabled = false;
        playerController = GetComponent<FPSController>();
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
