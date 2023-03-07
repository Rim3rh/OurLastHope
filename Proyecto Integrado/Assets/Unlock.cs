using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    private bool _estoyDentro;
    
    public Animator _anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_estoyDentro && Input.GetKeyDown(KeyCode.E))
        {
            _anim.Play("Upgrade");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _estoyDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _estoyDentro = false;
        }
    }
}
