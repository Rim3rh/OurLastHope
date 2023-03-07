using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveAlPlayer : MonoBehaviour
{
    public GameObject _player;
    public GameObject _dash;
    public GameObject _healthTaker;
    [SerializeField] private GameObject _spawnPoin1, _spawnPoin2, _spawnPoin3;
    public GameObject _cameraFOV;
    private int cont;
    public Animator _anim;
    void Update()
    {
        if (_player.GetComponent<PlayerMovement>()._imDying && cont == 0)
        {
            
            cont++;
            StartCoroutine(DontDie());
        }
    }
    public IEnumerator DontDie()
    {
        yield return new WaitForSeconds(3);
        _cameraFOV.GetComponent<TeleportScript>()._zoom = 34;
        switch (_player.GetComponent<PlayerMovement>().spawnlocation)
        {
            case 1:
                _player.transform.position = new Vector2(_spawnPoin1.transform.position.x, _spawnPoin1.transform.position.y);
                break;
            case 2:
                _player.transform.position = new Vector2(_spawnPoin2.transform.position.x, _spawnPoin2.transform.position.y);
                break;
            case 3:
                _player.transform.position = new Vector2(_spawnPoin3.transform.position.x, _spawnPoin3.transform.position.y);
                break;
        }
        _player.SetActive(true);
        
        _healthTaker.GetComponent<HealthManager>()._currentHealth = 100;
        _anim.Play("Reevive");
        yield return new WaitForSeconds(1);
        _player.GetComponent<PlayerMovement>()._imDying = false;

        cont = 0;
        StopAllCoroutines();
        _dash.GetComponent<PlayerDash>()._canDash = true;
        
    }
   
}
