using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCollider : MonoBehaviour
{

    [SerializeField] private GameObject _flyingEnemyScript;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _flyingEnemyScript.GetComponent<FlyingEnemyScript>()._flyingCollided = true;
            Destroy(this.gameObject);
        }
    }
}
