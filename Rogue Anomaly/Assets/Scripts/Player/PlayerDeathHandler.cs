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
        postDeathCamera.gameObject.SetActive(false);
        gameOverCanvas.enabled = false;
        playUICanvas.enabled = true;

        playerController = FindObjectOfType<FirstPersonController>();
        timerHandler = FindObjectOfType<Timer>();
    }

    public void HandleDeath()
    {   
        postDeathCamera.gameObject.SetActive(true);
        playerController.gameObject.SetActive(false);
        timerHandler.StopTimer();
        
        gameOverCanvas.enabled = true;
        playUICanvas.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
