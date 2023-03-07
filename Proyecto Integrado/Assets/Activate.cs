using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Activate : MonoBehaviour
{

    public GameObject _anim;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) _anim.SetActive(true);

    }

   



   

}
