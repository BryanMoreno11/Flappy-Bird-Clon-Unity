using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    //aributos
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Error!");
        }

        instance = this;

    }

    public void newGame()
    {
        this.gameData = new GameData();
    }
    //Carga la data guardada de un archivo mediante el Data Handler
    // Si no hay data simplemente iniciamos un Nuevo Juego
    public void loadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No hay data");
            newGame();
        }
        //Le pasa la data a los scripts que la necesitan

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.loadData(gameData);
        }
        Debug.Log("El puntaje de cargado es "+gameData.puntaje);
    }

    public void saveGame()
    {
        //Agarra los datos de los scripts que necesitamos
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.saveData(ref gameData);
        }

        Debug.Log("El puntaje de guardado es "+ gameData.puntaje);
        dataHandler.Save(gameData);
    }

    private void Start()
    {
        this.dataHandler= new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects= findAllDataPersistenceObjects();
        loadGame();
    }

    private void GameOver()
    {
        saveGame();
    }

    private List<IDataPersistence> findAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects= FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
