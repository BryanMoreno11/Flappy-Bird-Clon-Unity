using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class LogicaScript : MonoBehaviour
{
    //Variables
    public int puntuacion;
    public Text puntuacionTexto;
    public GameObject instruccion;
    public GameObject gameOverScreen;
    public int puntajeIncremental = 10;
    public int incremento=10;
    public int limiteIncremento = 40;
    public PipeMovement pipeMovement;
    public PipeSpawnScript spawn;
    public AudioSource scoreSound;
    public AudioSource gameSong;
    public static bool gameBegin=true;
    public GameObject panelPausa;
    public bool gameFinish = false;
    public bool pausedGame=false;

    private void Start()
    {
        pipeMovement = GameObject.FindGameObjectWithTag("pipeMovement").GetComponent<PipeMovement>();
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<PipeSpawnScript>();
        gameSong.Play();

    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gameBegin==false && gameFinish==false )
        {
            pausarJuego();

        }

        if (Input.GetKeyDown(KeyCode.Space) && pausedGame == true)
        {
           StartCoroutine(renaudarJuego());

        }
    }

    [ContextMenu("incrementar")]
    public void incrementarPuntuacion(int puntaje)
    {
        puntuacion += 1;
        puntuacionTexto.text= puntuacion.ToString();
        scoreSound.Play();
        if (puntuacion == puntajeIncremental && puntuacion<=limiteIncremento)
        {
           pipeMovement.incrementarVelocidad();
            spawn.reducirTiempoSpaw();
            puntajeIncremental += incremento;

        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameFinish = true;
        gameOverScreen.SetActive(true);
        float velocidadBase= pipeMovement.getVelocidadBase();
        pipeMovement.setVelocidad( velocidadBase );
    }

    public void toggleInstrucion(bool orden)
    {
        instruccion.SetActive(orden);
    }

    public int getPuntuacion()
    {
        return puntuacion;
    }

    public bool getGameBegin()
    {
        return gameBegin;
    }

    public void setGameBegin(bool valor)
    {
        gameBegin = valor;
    }

    public void pausarJuego()
    {
        Time.timeScale = 0;
        panelPausa.SetActive(true);
        pausedGame=true;
    }

    public IEnumerator renaudarJuego()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        Time.timeScale =1;
        panelPausa.SetActive(false);
        pausedGame = false;
    }

    public bool getPausedGame()
    {
        return pausedGame;
    }
}
