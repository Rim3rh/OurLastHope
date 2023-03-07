using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    

    public GameObject audios;


    private void Start()
    {
       
    }


    private void Update()
    {

        

            audios.GetComponent<AudioSource>().volume = GameManager.Instance.musicVolume;
    }


   

}