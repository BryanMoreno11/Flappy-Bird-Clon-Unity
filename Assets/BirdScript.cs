using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float fuerzaSalto;
    public LogicaScript logica;
    public bool birdIsAlive = true;
    protected Vector3 coordenadasCamara;
    protected float coordenadasY;

    void Start()
    {
        logica = GameObject.FindGameObjectWithTag("Logica").GetComponent<LogicaScript>();
        if (logica.getGameBegin() == true)
        {
            logica.toggleInstrucion(true);
            Time.timeScale = 0;

        }

    }

    void Update()
    {
        coordenadasCamara = Camera.main.WorldToViewportPoint(transform.position);
        coordenadasY = coordenadasCamara.y;

        if (coordenadasY < 0)
        {
            logica.gameOver();
            birdIsAlive=false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true && coordenadasY<0.95 && logica.getPausedGame()==false)
        {
            if (logica.getGameBegin() == true)
            {
                logica.toggleInstrucion(false);
                Time.timeScale = 1;
                logica.setGameBegin(false);

            }

            myRigidBody.velocity = new Vector2(0, 1) * fuerzaSalto;

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logica.gameOver();
        birdIsAlive=false;
    }
}


