using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TeleportScript : MonoBehaviour
{
    public GameObject _teleport;
    public int _zoom;
    public CinemachineVirtualCamera _camera;
    void Start()
    {
        _zoom = 34;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.m_Lens.FieldOfView = _zoom;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = _teleport.transform.position;
            _zoom = 55;
        }
    }
}
