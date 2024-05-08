using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;
    private NewBehaviourScript playerController;

    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private GameObject player;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        playerController = player.GetComponent<NewBehaviourScript>();
    }

    void Update()
    {
        if(Input.GetKeyDown(playerController.Pause))
        {
            if(isPaused) {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");

    }

    public void toMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
}
