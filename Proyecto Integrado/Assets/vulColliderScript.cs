using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vulColliderScript : MonoBehaviour
{
    public GameObject _boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {

            
            _boss.GetComponent<BossScript>()._damaged = true;
        }
    }
}
