using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GameObject _lastLevel;

    public void CreateLevel(string txtLevelNum)
    {
        var Level = (GameObject)Instantiate(Resources.Load("Prefabs/Levels/Level" + txtLevelNum));
        Level.gameObject.name = "bolum" + txtLevelNum;
        _lastLevel = Level;
    }

    public void DestroyLastLevel(string txtLastLevelNum)
    {
        Destroy(_lastLevel, 7);
    }
}
