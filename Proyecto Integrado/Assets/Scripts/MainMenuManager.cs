using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadFirstLevel();
        }
    }

 
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    
}
