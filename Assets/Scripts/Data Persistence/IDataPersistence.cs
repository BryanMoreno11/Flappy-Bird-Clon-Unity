using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence 
{
    void saveData(ref GameData data);
    void loadData( GameData data);
  
}
