using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemyDamageTaker : MonoBehaviour
{


    public Animator _anim;
    public bool _amIDead;
    public GameObject _meleEnemy;


    private void Update()
    {
        if (_meleEnemy.GetComponent<MeleEnemyScript>()._health <= 0)
        {
            _amIDead = true;
            _anim.Play("MeleEnemyDeath");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Defense"))
        {
           
        }

        if (collision.CompareTag("PlayerAttack"))
        {
            _meleEnemy.GetComponent<MeleEnemyScript>()._health--;
        }
    }



    

}
