using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _vulCollider;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _startPos;





    [SerializeField] private GameObject _AttackZone1;
    [SerializeField] private GameObject _AttackArea1;

    [SerializeField] private GameObject _AttackZone2;


    private bool _runingCase2, _runingCase3;
    public bool _vulnerable;
    public bool _damaged;
    private int _health;
    private bool _playerInRight;
    private float timer, timer2, timer3;

    int cont;
    public GameObject _text;

    private bool _beenVuled;
    private bool _LookingRight;
    public GameObject _enemy1, _enemy2, _enemy3, _enemy4, _enemy5, _enemy6, _enemy7, _enemy8;
    //public Transform _enemySpawner1, _enemySpawner2;

    private bool _finJuego;

    void Start()
    {
        _finJuego = false;
        _beenVuled = false;
        _LookingRight = false;
        _runingCase2 = false;
        _runingCase3 = false;
        _damaged = false;
        _AttackZone1.SetActive(false);
        _AttackArea1.SetActive(false);
        _health = 3;


        timer3 = 8f;
        timer2 = 3f;
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_health == 0)
        {
            _finJuego = true;
            _anim.Play("BossDie");
        }


        if (!_finJuego)
        {

            WhereAmILooking();
            if (_vulnerable)
            {
                _anim.Play("vul");
                StopAllCoroutines();
                if (_health == 2) _beenVuled = true;
            }
            if (_damaged)
            {
                _anim.Play("Damaged");
                StopAllCoroutines();
            }

            

            switch (_health)
            {

                case 3:

                    if (!_runingCase2)
                    {
                        // Debug.Log("RuningCase1");
                        timer -= Time.deltaTime;
                        if (timer <= 0)
                        {
                            StartCoroutine(BossAttack1());
                            timer = 10;
                        }

                    }





                    break;


                case 2:

                    if (!_runingCase3 && !_beenVuled)
                    {
                        _runingCase2 = true;
                        // Debug.Log("RuningCase2");
                        timer2 -= Time.deltaTime;
                        if (timer2 <= 0)
                        {
                            StartCoroutine(BossAttack2());
                            timer2 = 12;
                        }
                    }


                    break;


                case 1:
                    _runingCase3 = true;
                    timer3 -= Time.deltaTime;
                    if (cont == 0)
                    {
                        StartCoroutine(BossAttack3());
                        cont++;
                    }

                    break;


            }


        }


    }



   
    private IEnumerator BossAttack3()
    {

        yield return new WaitForSeconds(3);
        if (_LookingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (_playerInRight)
        {
            _rb.velocity = new Vector2(-23, 0);
        }
        else
        {
            _rb.velocity = new Vector2(23, 0);
        }

        yield return new WaitForSeconds(1.6f);
        _rb.velocity = Vector2.zero;





        VulnerableToF();
        DamagedToF();
        LookAtPlayer();




        //invoke
        _anim.Play("Invoke");

        yield return new WaitForSeconds(2);
        _enemy1.SetActive(true);
        _enemy2.SetActive(true);
        yield return new WaitForSeconds(2);


        //hit

        _AttackZone1.SetActive(true);
        yield return new WaitForSeconds(1);
        _AttackZone1.SetActive(false);
        _anim.Play("AA");
        yield return new WaitForSeconds(2);



     

        //vul

        _rb.velocity = Vector2.zero;
        _anim.Play("prevul");
        yield return new WaitForSeconds(4);
        _anim.Play("BOSS");
        yield return new WaitForSeconds(1);



        //invoke
        LookAtPlayer();
        _anim.Play("Invoke");

        yield return new WaitForSeconds(2);
        _enemy3.SetActive(true);
        _enemy4.SetActive(true);
        yield return new WaitForSeconds(2);



        //hit
        _AttackZone1.SetActive(true);
        yield return new WaitForSeconds(1);
        _AttackZone1.SetActive(false);
        _anim.Play("AA");
        yield return new WaitForSeconds(2);






        //vul

        _rb.velocity = Vector2.zero;
        _anim.Play("prevul");
        yield return new WaitForSeconds(4);
        _anim.Play("BOSS");
        yield return new WaitForSeconds(1);







        //invoke
        LookAtPlayer();
        _anim.Play("Invoke");

        yield return new WaitForSeconds(2);
        _enemy5.SetActive(true);
        _enemy6.SetActive(true);
        yield return new WaitForSeconds(2);



        //hit
        _AttackZone1.SetActive(true);
        yield return new WaitForSeconds(1);
        _AttackZone1.SetActive(false);
        _anim.Play("BOSS");
        _anim.Play("AA");
        yield return new WaitForSeconds(2);





        //vul

        _rb.velocity = Vector2.zero;
        _anim.Play("prevul");
        yield return new WaitForSeconds(4);
        _anim.Play("BOSS");
        yield return new WaitForSeconds(1);









        //invoke
        LookAtPlayer();
        _anim.Play("Invoke");

        yield return new WaitForSeconds(2);
        _enemy7.SetActive(true);
        _enemy8.SetActive(true);
        yield return new WaitForSeconds(2);



        //hit
        _AttackZone1.SetActive(true);
        yield return new WaitForSeconds(1);
        _AttackZone1.SetActive(false);
        _anim.Play("AA");
        yield return new WaitForSeconds(2);



      



        //vul

        _rb.velocity = Vector2.zero;
        _anim.Play("prevul");
        yield return new WaitForSeconds(4);
        _anim.Play("BOSS");
        yield return new WaitForSeconds(1);



    }

    private IEnumerator BossAttack2()
    {
   
        LookAtPlayer();
        _AttackZone2.SetActive(true);
        yield return new WaitForSeconds(1);
        _AttackZone2.SetActive(false);
        _anim.Play("Envestir");
        yield return new WaitForSeconds(0.3f);
        if (_playerInRight)
        {
            _rb.velocity = new Vector2(46, 0);
        }
        else
        {
            _rb.velocity = new Vector2(-46, 0);
        }
        
        yield return new WaitForSeconds(0.8f);
        _rb.velocity = Vector2.zero;
        _anim.Play("prevul");
        yield return new WaitForSeconds(3);


        
        _anim.Play("BOSS");
        if (_LookingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (_playerInRight)
        {
            _rb.velocity = new Vector2(-23, 0);
        }
        else
        {
            _rb.velocity = new Vector2(23, 0);
        }
        
        yield return new WaitForSeconds(1.6f);
        _rb.velocity = Vector2.zero;
    }

    private IEnumerator BossAttack1()
    {
        VulnerableToF();
        DamagedToF();
        LookAtPlayer();
        _AttackZone1.SetActive(true);
        yield return new WaitForSeconds(1);
        _AttackZone1.SetActive(false);
        _anim.Play("AA");
        yield return new WaitForSeconds(3);
        _anim.Play("prevul");
        yield return new WaitForSeconds(4);
        _anim.Play("BOSS");
    }


    public void Attack1()
    {
        _AttackArea1.SetActive(true);
    }
    public void AttackArea1ToF()
    {
        _AttackArea1.SetActive(false);
    }

    public void DamagedToF()
    {
        _damaged = false;
    }
    public void VulnerableToF()
    {
        _vulnerable = false;
    }
    public void TakeDamage()
    {
        VulnerableToF();
        DamagedToF();
        StopAllCoroutines();
        _health--;
        _anim.Play("BOSS");
    }
    void LookAtPlayer()
    {

        if (transform.position.x > _player.transform.position.x)
        {
            _playerInRight = false;
        }
        else
        {
            _playerInRight = true;
        }
        transform.eulerAngles = (_playerInRight ? new Vector3(0, 0, 0) : transform.eulerAngles = new Vector3(0, 180, 0));

    }
    private void WhereAmILooking()
    {
        if (transform.eulerAngles == new Vector3(0, 0, 0))
        {

            _LookingRight = true;
        }
        else
        {
            _LookingRight = false;
        }
    }

    public void DestroyGO()
    {

        _text.SetActive(true);


        Destroy(gameObject);
    }
}
