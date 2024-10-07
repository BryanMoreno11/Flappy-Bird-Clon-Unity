using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public LogicaScript logica;
    void Start()
    {
        logica = GameObject.FindGameObjectWithTag("Logica").GetComponent<LogicaScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logica.incrementarPuntuacion(1);

        }

    }
}
