using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool gameIsPaused = false;
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
        if(Input.GetKeyDown(playerController.Escape))
        {
            if(gameIsPaused) {
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
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
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
