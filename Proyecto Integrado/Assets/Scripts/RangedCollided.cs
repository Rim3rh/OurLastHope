using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCollided : MonoBehaviour
{
    public bool _rangedCollided;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rangedCollided = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rangedCollided = false;
        }
    }
}
