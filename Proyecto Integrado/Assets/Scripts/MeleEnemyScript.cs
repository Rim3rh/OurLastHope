using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemyScript : MonoBehaviour
{
    //[SerializeField] private GameObject _healthTaker;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _damageTaker;

    public bool _detected;
    private bool _playerInRight;
    [SerializeField] private GameObject _attackRange;
    public Animator _anim;
    float timer;


    private bool _isAttacking;

    public int _health;

    


    void Start()
    {
        _health = 2;
        timer = 0.4f;
    }

 
    void Update()
    {

        if (_damageTaker.GetComponent<MeleEnemyDamageTaker>()._amIDead == false)
        {

            

            WhereIsPlayer();

            if (_detected)
            {

                switch (_health)
                {
                    case 2:
                        if (!_isAttacking)
                        {
                            _anim.Play("MeleEnemy-IDLE");
                        }

                        if (!_attackRange.GetComponent<AttackRangeScript>()._isTouching)
                        {
                            if (_playerInRight)
                            {

                                transform.eulerAngles = new Vector3(0, 180, 0);
                            }
                            else
                            {
                                transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_player.transform.position.x, transform.position.y), 5 * Time.deltaTime);
                        }
                        else
                        {

                            timer -= Time.deltaTime;
                            if (timer <= 0)
                            {
                                _anim.Play("MeleEnemy-ATTACK");
                            }

                        }


                        break;
                    case 1:
                        if (!_isAttacking)
                        {
                            _anim.Play("MeleEnemy-IDLE");
                        }

                        if (!_attackRange.GetComponent<AttackRangeScript>()._isTouching)
                        {
                            if (_playerInRight)
                            {

                                transform.eulerAngles = new Vector3(0, 180, 0);
                            }
                            else
                            {
                                transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(_player.transform.position.x, transform.position.y), 5 * Time.deltaTime); 
                        }
                        else
                        {

                            timer -= Time.deltaTime;
                            if (timer <= 0)
                            {
                                _anim.Play("MeleEnemy-ATTACK");
                            }

                        }


                        break;

                }








            }
        }
       

    
    }
    void WhereIsPlayer()
    {

        if (transform.position.x > _player.transform.position.x)
        {
            _playerInRight = false;
        }
        else
        {
            _playerInRight = true;
        }


    }
   
 

    
    public void ReserTimer()
    {
        timer = 2;
        _anim.Play("MeleEnemy-IDLE");
    }




    public void IsAttackingToT()
    {
        _isAttacking = true;
    }
    public void IsAttackingToF()
    {
        _isAttacking = false;
    }
    public void Die()
    {
        Destroy(gameObject);
    }


}
