using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyDamakeTaker : MonoBehaviour
{
    public GameObject _fly;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            _fly.GetComponent<FlyingEnemyScript>()._amIDead = true;
        }
        
    }
}
