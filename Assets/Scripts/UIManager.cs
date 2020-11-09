using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    bool GamePaused;
    public GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        GamePaused = false;
    }

    void Update()
    {
        if(GamePaused)
        {
            Time.timeScale = 0;
        }
            
        else
        {
            Time.timeScale = 1; 
        }
            
    }

    public void PauseGame()
    {
        GamePaused = true;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        GamePaused = false;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //pausePanel.SetActive(false);
    }
}
