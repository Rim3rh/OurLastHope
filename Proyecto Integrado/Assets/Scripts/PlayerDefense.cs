using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    public bool _unlocked;
    public bool _isDeffending;
    public Animator _anim;

    [SerializeField] private GameObject _groundCheck;
    [SerializeField] private GameObject _dash;
    [SerializeField] private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _isDeffending = false;
        _unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && _dash.GetComponent<PlayerDash>()._isDashing == false && _groundCheck.GetComponent<Grounded>()._isGrounded == true && _unlocked)
        {
            Defend();
        }
    }
    private void Defend()
    {

        _player.GetComponent<PlayerMovement>().SetVelTo0();

        _isDeffending = true;
        _anim.Play("PlayerDef");
    }
    

    
}
