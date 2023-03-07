using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoinVisuals : MonoBehaviour
{

    public GameObject _ligth;
   




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player")) _ligth.SetActive(true);

    }
}
