using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRangeMele : MonoBehaviour
{

    public GameObject _meleEnemy;
    private bool _inCorrutine1;
    private bool _inCorrutine2;
    public bool _detected;

    void Start()
    {
        _detected = false;
        _inCorrutine1 = false;
        _inCorrutine2 = false;
        StartCoroutine(Corrutine());
    }

    private void FixedUpdate()
    {
        if (_inCorrutine1)
        {
            _meleEnemy.transform.Translate(-0.1f, 0, 0);
            _meleEnemy.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (_inCorrutine2)
        {
            _meleEnemy.transform.Translate(-0.1f, 0, 0);
            _meleEnemy.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    IEnumerator Corrutine()
    {
        _inCorrutine1 = true;
        yield return new WaitForSeconds(3);
        _inCorrutine1 = false;
        _inCorrutine2 = true;
        yield return new WaitForSeconds(3);
        _inCorrutine2 = false;
        StartCoroutine(Corrutine());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _meleEnemy.GetComponent<MeleEnemyScript>()._detected = true;
            Destroy(this.gameObject);
            
        }
    }
}
