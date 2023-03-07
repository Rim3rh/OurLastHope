using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    public Transform _shootingPos;
    Transform _transform;

    private GameObject _player;
    

    Vector2 prueba;

    

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.GetComponent<Transform>();
        _player = GameObject.Find("Player");
       

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            shoot();
        }
            
        
    }

    public void shoot() 
    {
        if(_player.GetComponent<PlayerDefense>()._isDeffending == false)
        {
            prueba = _player.transform.position;
            DrawRay(_shootingPos.transform.position, prueba);
            _player.GetComponent<PlayerMovement>()._frozen = true;
            //Aqui tambien tendrias que poner como q el personaje se frezea(animacion)
        }
        if (_player.GetComponent<PlayerDefense>()._isDeffending == true)
        {
            StartCoroutine(AbilityBock());
        }


    } 
   
    void DrawRay(Vector2 startPos, Vector2 endPos)
    {
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
       
    }

    private IEnumerator AbilityBock()
    {
        prueba = _player.transform.position;
        DrawRay(_shootingPos.transform.position, prueba);
        yield return new WaitForSeconds(0.1f);
        DrawRay(Vector2.zero, Vector2.zero);
        //Aqui Harias Spawn de el sistema de particulaas de blockeo
    }
   
}
