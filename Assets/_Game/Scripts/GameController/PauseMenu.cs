using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    public void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;

    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
