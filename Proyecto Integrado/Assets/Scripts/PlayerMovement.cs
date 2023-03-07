using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _anim;


    private Rigidbody2D _rb;
    private GameObject _groundCheck;
    public GameObject _dash;
    public GameObject _def;
    public GameObject _healthTaker;
    public bool _facinRight = true;
    public bool _frozen;
    public bool _isJumpingUP;
    public bool _isJumpingDOWN;
    public bool _isAttacking;

    [SerializeField] private float _Acceleration = 50f;
    [SerializeField] private float _MaxSpeed = 12f;
    [SerializeField] private float _Deceleration = 10f;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _ariPull = 2.5f;
    private float _HMovement;
    private bool _isGrounded;
    private bool _changingDirection => (_rb.velocity.x < 0 && _HMovement > 0) || (_rb.velocity.x > 0 && _HMovement < 0);


    [SerializeField] private float _fallMultiplier = 8f;
    [SerializeField] private float _lowJumpFallMultiplier = 5f;

    public float  _coyoteTime, _coyoteTimer;
    public float _bufferTime, _bufferTimer;

    public bool _imDying;

    [SerializeField] private GameObject _spawnPoin1, _spawnPoin2, _spawnPoin3;
    public int spawnlocation;

    public bool _cantClick;

    void Start()
    {

        _cantClick = false;
        spawnlocation = 1;


        _coyoteTime = 0.15f;
        _bufferTime = 0.15f;



        _frozen = false;
        _facinRight = true;
        _rb = GetComponent<Rigidbody2D>();
        _groundCheck = GameObject.Find("GroundCheck");
    }


    void Update()
    {
        if (!_imDying)
        {

            _HMovement = GetInput().x;
            if (_bufferTimer > 0 && _coyoteTimer > 0 && _dash.GetComponent<PlayerDash>()._cantJump == false && _def.GetComponent<PlayerDefense>()._isDeffending == false && !_isAttacking)
            {

                Jump();
            }
            if (Input.GetButtonDown("Fire1") && _dash.GetComponent<PlayerDash>()._isDashing == false && _groundCheck.GetComponent<Grounded>()._isGrounded == true && !_cantClick)
            {
                SetVelTo0();
                _anim.Play("AA");
            }

            BufferUpgrade();



        }





    }
    private void FixedUpdate()
    {

        if (!_imDying)
        {



            if (_dash.GetComponent<PlayerDash>()._isDashing == false && _def.GetComponent<PlayerDefense>()._isDeffending == false && _isAttacking == false)
            {

                JumpUpgrade();

                Animations();

                CheckJumpState();
                MoveCharacter();
                GroundCheck();
                EulerAngles();

                AplyDeceleration();
                FallMiltiplier();
                if (_isGrounded)
                {
                    AplyDeceleration();
                }
                else
                {
                    AplyAirDeceleration();
                }
            }



        }



    }

    public void Animations()
    {
        if (_isJumpingUP && !_isGrounded)
        {
            _anim.Play("JumpUP");
        }else if (_isJumpingDOWN && !_isGrounded)
        {
            _anim.Play("JumpDown");
        }else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            _anim.Play("IDLE");
        }else if (Mathf.Abs(_rb.velocity.x) > 0 && Mathf.Abs(_rb.velocity.x) < 10) {
            _anim.Play("PRERUN");

        }
        
        if(Mathf.Abs(_rb.velocity.x) > 10 && _isJumpingUP == false && _isJumpingDOWN == false)
        {
            _anim.Play("RUN");
        }





       

    }



    private void CheckJumpState()
    {
        if(_rb.velocity.y == 0)
        {
            _isJumpingUP = false;
            _isJumpingDOWN = false;
            
        }else if(_rb.velocity.y > 0)
        {
            _coyoteTimer = 0;
            _isJumpingUP = true;

        }else if(_rb.velocity.y < 0)
        {
            _isJumpingUP = false;
            _isJumpingDOWN = true;
        }
    }
    private void EulerAngles()
    {
        if (_HMovement < 0)
        {
            transform.eulerAngles = new Vector3(0, 180);
            _facinRight = false;
        }
        if (_HMovement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0);
            _facinRight = true;
        }
    }
    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter()
    {
        _rb.AddForce(new Vector2(_HMovement, 0f) * _Acceleration);


       
            if (Mathf.Abs(_rb.velocity.x) > _MaxSpeed)
            {
                _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * _MaxSpeed, _rb.velocity.y);
            }
        

    }
    private void AplyDeceleration()
    {
        if (Mathf.Abs(_HMovement) < 0.4 || _changingDirection)
        {
            _rb.drag = _Deceleration;
        }
        else
        {
            _rb.drag = 0f;
        }
    }
    private void AplyAirDeceleration()
    {
       
            _rb.drag = _ariPull;
       
    }

    private void Jump()
    {
       
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse);
    }

    private void GroundCheck()
    {
        
            _isGrounded = _groundCheck.GetComponent<Grounded>()._isGrounded;
        if (_isGrounded == true)
        {
            _dash.GetComponent<PlayerDash>()._cantJump = false;
        }

    }

    private void FallMiltiplier()
    {
        if(_rb.velocity.y < 0)
        {
           
            _rb.gravityScale = _fallMultiplier;
        }
        else if(_rb.velocity.y >0 && !Input.GetButtonDown("Jump"))
        {
            _rb.gravityScale = _lowJumpFallMultiplier;
            
        }
        else
        {
            _rb.gravityScale = 1f;
        }
    }
    public void IsDefendingToF()
    {
        _def.GetComponent<PlayerDefense>()._isDeffending = false;
    }

    public void SetVelTo0()
    {
        _rb.velocity = Vector2.zero;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("MovPlat"))
        {
            transform.parent = collision.transform;
        }

       

        if (collision.CompareTag("Spawnpoin2"))
        {
            spawnlocation = 2;
        }
        if (collision.CompareTag("Spawnpoin3"))
        {
            spawnlocation = 3;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MovPlat"))
        {
            transform.parent = null;
        }
    }



    private void JumpUpgrade()
    {
        if (_isGrounded)
        {
            _coyoteTimer = _coyoteTime;
        }
        else
        {
            _coyoteTimer -= Time.deltaTime;
     
        }

        
    }

    

    private void BufferUpgrade()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _bufferTimer = _bufferTime;
        }
        else
        {
            _bufferTimer -= Time.deltaTime;
        }
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
        _imDying = true;
        SetVelTo0();
        _anim.Play("DEAth1");
    }
    

    public void DestroyGameObj()
    {
        //_imDying = true;
        gameObject.SetActive(false);
       
    }
    public void Activate()
    {

        gameObject.SetActive(true);
    }

    public void Unlock()
    {
        _def.GetComponent<PlayerDefense>()._unlocked = true;
    }




}
