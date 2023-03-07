using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCoolDown : MonoBehaviour
{

    public bool _coolDownStart;
    private float _dashCoolDown;
    public Image CoolDown;
    private float timer;
    void Start()
    {
        timer = 1;
        _dashCoolDown = 2.3f;
        
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown.fillAmount = timer;
        if (_coolDownStart)
        {
            timer -= 1.0f/_dashCoolDown * Time.deltaTime;
        }
        if(timer <= 0)
        {
            _coolDownStart = false;
            timer = 1;
        }

        


    }
}
