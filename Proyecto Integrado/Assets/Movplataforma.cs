using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movplataforma : MonoBehaviour
{
    public GameObject movobjeto;

    public Transform Incio;
    public Transform Final;

    public float speed;

    private Vector3 movimiento;


    // Start is called before the first frame update
    void Start()
    {

        movimiento = Final.position;

    }

    // Update is called once per frame
    void Update()
    {
        /* MoveTowars para mover en distintas direciones. Pide tres cosas, donde estamos, hacía donde queremos ir y a que velociad.*/

        movobjeto.transform.position = Vector3.MoveTowards(movobjeto.transform.position, movimiento, speed * Time.deltaTime);

        if (movobjeto.transform.position == Final.position)
        {
            movimiento = Incio.position;
        }

        if (movobjeto.transform.position == Incio.position)
        {
            movimiento = Final.position;
        }


    }


}