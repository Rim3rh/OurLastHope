using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject _collider;
    [SerializeField] private Animator _animator;
    

    private GameObject _player;

    private bool _hasSpawned;

    void Start()
    {
        _player = GameObject.Find("Player");

    }

    void Update()
    {
        Transform();
      

    }

    private void Transform()
    {
        if (_collider.GetComponent<RangedCollided>()._rangedCollided == true && _hasSpawned == false)
        {
            _animator.Play("Ranged-RISE");
        }
    }

    public void HasSpawned()
    {
        
        _hasSpawned = true;
        StartCoroutine(shooting());
        
    }

    IEnumerator shooting()
    {
        _animator.Play("Ranged-IDLE");
        yield return new WaitForSeconds(4f);
        _animator.Play("Ranged-Shoot");
    }

    
   
}
