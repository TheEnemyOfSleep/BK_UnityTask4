using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _successMenu;
    [SerializeField] private bool _isPaused = false;

    private bool _gameFinished = false;   

    public GameObject Menu
    {
        get => _pauseMenu;
        set => _pauseMenu = value;
    }

    public GameObject SuccessMenu
    {
        get => _successMenu;
        set => _successMenu = value;
    }

    public bool IsPaused
    {
        get => _isPaused;
        set => _isPaused = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_gameFinished)
        {
            if (_isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _isPaused = true;
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameFinished()
    {
        _successMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _gameFinished = true;
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
