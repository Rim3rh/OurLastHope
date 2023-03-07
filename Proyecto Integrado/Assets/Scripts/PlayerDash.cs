using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject _player;
    public GameObject _def;
    [SerializeField] private Animator _anim;
    public GameObject _DashCD;
    //private float _baseGrav;

    [SerializeField] private float _dashingTime = 0.3f;
    [SerializeField] private float _dashingCD = 4.0f;
    [SerializeField] private float _dashForce = 20;
    public bool _isDashing;
    public bool _canDash;
    public bool _cantJump;
    void Start()
    {
        _cantJump = false;
        _dashingTime = 0.3f;
        _dashingCD = 2.0f;
        _dashForce = 40;
        _canDash = true;
        _isDashing = false;
        _rb = this.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Dash") && _canDash && !_def.GetComponent<PlayerDefense>()._isDeffending && !_player.GetComponent <PlayerMovement>()._isAttacking)
        {
           
            StartCoroutine(Dash());
        }
        
    }

    private IEnumerator Dash()
    {

        _cantJump = true;

        _isDashing = true;
        _anim.Play("PlayerDash");
        _canDash = false;
        _rb.gravityScale = 0;

        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _dashForce, 0);
        }
        else
        {
            if (_player.GetComponent<PlayerMovement>()._facinRight == true)
            {
                _rb.velocity = new Vector2(1 * _dashForce, 0);
            }
            else
            {
                _rb.velocity = new Vector2(-1 * _dashForce, 0);
            }
        }


        _DashCD.GetComponent<DashCoolDown>()._coolDownStart = true;
        yield return new WaitForSeconds(_dashingTime);
        
        _isDashing = false;
        
        _rb.gravityScale = 1;

        
        yield return new WaitForSeconds(_dashingCD);
        
        _canDash = true;

    }
   
}
