using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] 
    public Canvas gameOverCanvas;


    private FirstPersonController playerController;
    private Timer timerHandler;
    
    private void Start() {
        gameOverCanvas.enabled = false;

        playerController = FindObjectOfType<FirstPersonController>();
        timerHandler = FindObjectOfType<Timer>();
    }

    public void HandleDeath()
    {
        playerController.enabled = false;
        timerHandler.StopTimer();

        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
