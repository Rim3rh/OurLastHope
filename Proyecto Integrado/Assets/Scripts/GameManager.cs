using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    
    public float musicVolume;


    private void Awake()
    {

        musicVolume = 0.5f;
        Instance = this;
        DontDestroyOnLoad(gameObject);


      
    }

   

  


}
