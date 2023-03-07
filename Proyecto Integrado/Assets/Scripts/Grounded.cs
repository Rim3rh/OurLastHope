using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool _isGrounded;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("MovPlat"))
        {
            _isGrounded = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ground") || other.CompareTag("MovPlat"))
        {
            _isGrounded = false;
        }
    }
}
