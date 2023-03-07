using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float _maxHealth;
    public float _currentHealth;
    public GameObject _player;
    void Start()
    {
        _maxHealth = 100f;
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        AmImDead();


        //Debug.Log(_currentHealth);
    }

  
    private void AmImDead()
    {
        if(_currentHealth <= 0)
        {
            _player.GetComponent<PlayerMovement>().Die();
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
         
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void"))
        {
            TakeDamage(100);
            
        }

        if (collision.CompareTag("BossGroundAttack"))
        {
            TakeDamage(25);

        }
        if (collision.CompareTag("BossDontTuch"))
        {
            TakeDamage(15);

        }

    }
}
