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
  

    void Start()
    {

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

    

   


}
