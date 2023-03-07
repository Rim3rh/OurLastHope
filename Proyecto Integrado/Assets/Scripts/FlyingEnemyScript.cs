using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _healthTaker;
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _punto1;
    private float _speed;
    public bool _amIDead;
    [SerializeField] private bool _hasHit;
    public bool _flyingCollided;
    private bool _inCorrutine;
    void Start()
    {
        _amIDead = false;
        _inCorrutine = false;
        
        _flyingCollided = false; 
        _speed = 4;
    }
    void Update()
    {

        if (_amIDead)
        {
            _anim.Play("FlyDead");
        }

    }
    private void FixedUpdate()
    {
       
        if (!_amIDead)
        {
            if (!_flyingCollided)
            {
                _anim.Play("RISE");
            }
              
            if (_flyingCollided)
            {

                if (!_hasHit)
                {
                    Chasing();
                }
                if (_inCorrutine)
                {
                    _anim.Play("FylingEnemy-IDLE");
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(_punto1.transform.position.x, _punto1.transform.position.y), _speed * Time.deltaTime);
                }



            }


        }
      
    }


    void Chasing()
    {
        _speed = 10;
        _anim.Play("FylingEnemy-Attack");
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_player.transform.position.x, _player.transform.position.y + 1f), _speed * Time.deltaTime);
    }

    IEnumerator AvoidP()
    {
        
        
        _inCorrutine = true;
        yield return new WaitForSeconds(3f);
        
        _speed = 4;
        yield return new WaitForSeconds(3f);
        _hasHit = false;
        _inCorrutine = false;
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            _hasHit = true;
            _healthTaker.GetComponent<HealthManager>().TakeDamage(20);
            StartCoroutine(AvoidP());
        }
    }

    public void DestroyGObj()
    {
        Destroy(gameObject);
    }

    private void FlyingCollidedToT()
    {
        _flyingCollided = true;
    }


}
