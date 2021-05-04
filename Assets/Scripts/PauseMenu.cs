using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public bool gameOver = false;
    public GameObject blurPanel;
    public GameController gameController;

    void Update()
    {
        if (gameController.gameOverPanel.activeSelf)
        {
            gameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Cursor.visible = false;
        blurPanel.SetActive(false);
    }

    void Pause()
    {
        if (!gameOver)
        {
            blurPanel.SetActive(true);
            Cursor.visible = true;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }
    }

    public void LoadMenu()
    {
        if (GameObject.Find("AlloyPowerup") != null)
        {
            GameObject[] alloyPowerups = GameObject.FindGameObjectsWithTag("AlloyPowerup");
            foreach (GameObject alloyPowerup in alloyPowerups)
            {
                Destroy(alloyPowerup);
            }
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
