using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _optionsMenu;
    public GameObject _player;
    //public GameObject _healthUI;
    public bool _isPaused, _optionsMenuOpen;


   

    // Start is called before the first frame update
    void Start()
    {
        _optionsMenuOpen = false;
        _optionsMenu.SetActive(false);
        _pauseMenu.SetActive(false);
        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_optionsMenuOpen)
        {
            if (_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        _player.GetComponent<PlayerMovement>()._cantClick = true;
        Cursor.visible = true;
     //   _healthUI.SetActive(false);
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }
    public void ResumeGame()
    {
        _player.GetComponent<PlayerMovement>()._cantClick = false;
        Cursor.visible = false;
        _pauseMenu.SetActive(false);
    //    _healthUI.SetActive(true);
        Time.timeScale = 1f;
        _isPaused = false;
    }


    public void OpenOptions()
    {
        _optionsMenuOpen = true;
        _pauseMenu.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 0f;
        _optionsMenu.SetActive(true);

    }
    public void CloseOptionsMenu()
    {
        _optionsMenuOpen = false;
        _pauseMenu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        _optionsMenu.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
