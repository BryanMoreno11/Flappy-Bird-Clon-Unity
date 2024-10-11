using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public const float velocidadBase= 10;
    protected static float velocidad = velocidadBase;
    public float incrementoVelocidad = 2.5f;
    protected Vector3 coordenadasCamara;
    protected float coordenadasX;
    public GameObject bottomPipe;
    public GameObject topPipe;
    public float limiteSumaPipe=8;
  
    //Maximo 7
    void Start()
    {
 
        generarPosicion();
       
    }

    void Update()
    {
        coordenadasCamara = Camera.main.WorldToViewportPoint(transform.position);
        coordenadasX=coordenadasCamara.x;

        if (coordenadasX<0)
        {
            Destroy(gameObject);
        }

        transform.position = transform.position + (Vector3.left * velocidad)*Time.deltaTime;
    }


    public void bajarTopPipe(float valor)
    {

        topPipe.transform.position = new Vector3(topPipe.transform.position.x, topPipe.transform.position.y - valor, 0);

    }

    public void subirBottomPipe(float valor)
    {
        bottomPipe.transform.position = new Vector3(bottomPipe.transform.position.x, bottomPipe.transform.position.y + valor, 0);

    }

    public void incrementarVelocidad()
    {

        velocidad += incrementoVelocidad;

    }

    public float getVelocidadBase()
    {
        return velocidadBase;
    }

    public void setVelocidad(float velocidad_nueva)
    {
        velocidad = velocidad_nueva;
    }

    public void generarPosicion()
    {
        float valorTopPipe = Random.Range(-1f, 7f);
        float valorBottomPipe = Random.Range(-1f, 7f);
        float sumaPipe = valorTopPipe + valorBottomPipe;
        if (sumaPipe > limiteSumaPipe)
        {
            if (valorTopPipe > valorBottomPipe)
            {
                valorBottomPipe = 0;
            }
            else
            {
                valorTopPipe = 0;
            }
        }
        bajarTopPipe(valorTopPipe);
        subirBottomPipe(valorBottomPipe);
    }

    

   


}
