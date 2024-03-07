using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [Header("UIControl")]
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _loseMenu;
    [SerializeField] private TextMeshProUGUI _currentScoreTextView;
    private int _currentScore;

    [Header("TimerState")]
    [SerializeField] public TextMeshProUGUI _timerText;
    public float TimeLeft;
    public bool _timerOn = false;
    [SerializeField] GameObject _player;

    private int _inventory = 0;
    [SerializeField] GameObject _winZone;
    [SerializeField] private AudioSource _loseSound;
    private void Awake()
    {
        //allow the mouse cursor to move around the game window
        Cursor.lockState = CursorLockMode.Locked;
        //make the mouse curtsor visible
        Cursor.visible = false;
        _timerOn = true;

    }

    // Update is called once per frame
    private void Update()
    {

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Pause();
        }

        if (_player != true)
        {
            _timerOn = false;
        }

        if (_timerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                if (_loseMenu != null)
                {
                    _loseMenu.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                    //make the mouse cursor visible
                    Cursor.visible = true;
                }
                // do something!
                if (_loseSound != null)
                {
                    AudioSource newSound = Instantiate(_loseSound,
                        transform.position, Quaternion.identity);
                    Destroy(newSound.gameObject, newSound.clip.length);
                }
                _player.SetActive(false);
                _timerOn = false;
            }
        }
    }

    public void ExitLevel()
    {
        //compare score to highscore
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            //save current score as new highscore
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseScore(int scoreIncrease)
    {
        //increse score
        _currentScore += scoreIncrease;
        //update score display, so we can see new score
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    public void Pause()
    {
        _pauseMenu.SetActive(true);
        //allow the mouse cursor to move around the game window
        Cursor.lockState = CursorLockMode.Confined;
        //make the mouse cursor visible
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _pauseMenu.SetActive(false);
        //allow the mouse cursor to move around the game window
        Cursor.lockState = CursorLockMode.Locked;
        //make the mouse cursor visible
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        ExitLevel();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void AddInventory(int inventoryIncrease)
    {
        _inventory += inventoryIncrease;
        IncreaseScore(100);
        Debug.Log("IntelAdded " + _inventory);
        if(_inventory == 4)
        {
            _winZone.SetActive(true);
        }
    }

}
