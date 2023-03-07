using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{
    float contador;
    bool prueba1;
    void Start()
    {
        contador = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(contador);
        if ( prueba1 == true)
        {
            Debug.Log("ha Comenzado");
            contador -= Time.deltaTime;

        }

        if(contador <= 0)
        {
            Debug.Log("Se ha terminado");
            prueba1 = false;
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            FuncionQuellamas();
        }
    }


    void FuncionQuellamas()
    {
        contador = 10;
        prueba1 = true;
    }
}
