using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float tiempoSpawn=2;
    private float timer = 0;
    public float alturaPipe=10;
    public float restadorSpaw=0.25f;
    void Start()
    {
        spawnearPipes();
    }

    void Update()
    {

        if (timer >= tiempoSpawn)
        {
            spawnearPipes();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }

    public  void spawnearPipes()
    {

        float alturaMinima= transform.position.y-alturaPipe;
        float alturaMaxima= transform.position.y+alturaPipe;
        float posicionRandom = Random.Range(alturaMinima, alturaMaxima);
        if ((posicionRandom >= 4 && posicionRandom < 6) || (posicionRandom <= 0 && posicionRandom <= -3 && posicionRandom > -6))
        {
            posicionRandom = 1;
        }

        Instantiate(pipe, new Vector3(transform.position.x,posicionRandom, 0), transform.rotation);
    }

    public void setTiempoSpawn(float tiempo)
    {
        tiempoSpawn = tiempo;
    }

    public float getTiempoSpawn()
    {
        return tiempoSpawn;
    }

    public void reducirTiempoSpaw()
    {
        if(tiempoSpawn > 1)
        {
            tiempoSpawn -= restadorSpaw;

        }
    }


}
