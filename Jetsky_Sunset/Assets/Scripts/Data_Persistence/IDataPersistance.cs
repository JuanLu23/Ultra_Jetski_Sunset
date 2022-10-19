using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hay que pasar esta interface a otros scripts, junto con las funciones.
public interface IDataPersistance
{
    void LoadData(GameData data);

    void SaveData(ref GameData data);
}
