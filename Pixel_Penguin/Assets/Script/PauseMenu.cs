using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private GameOver gameOverScript;

    void Start()
    {
        // Find the GameOver script in the scene
        gameOverScript = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        // Check if the game over panel is not active before toggling the pause menu
        if (!gameOverScript.gameOverPanel.activeSelf)
        {
            bool isPaused = pauseMenu.activeSelf;
            pauseMenu.SetActive(!isPaused);

            // Adjust time scale based on whether the pause menu is active or not
            Time.timeScale = isPaused ? 1f : 0f;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
