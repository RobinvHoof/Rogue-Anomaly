using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] 
    public Canvas gameOverCanvas;

    [SerializeField]
    public Canvas playUICanvas;

    [SerializeField]
    public Camera postDeathCamera;


    private FirstPersonController playerController;
    private Timer timerHandler;
    
    private void Start() {
        gameOverCanvas.enabled = false;
        playUICanvas.enabled = true;
        postDeathCamera.gameObject.SetActive(false);

        playerController = FindObjectOfType<FirstPersonController>();
        timerHandler = FindObjectOfType<Timer>();
    }

    public void HandleDeath()
    {
        playerController.gameObject.SetActive(false);
        postDeathCamera.gameObject.SetActive(true);
        playUICanvas.enabled = false;
        timerHandler.StopTimer();

        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
