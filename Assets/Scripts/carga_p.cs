using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carga_p : MonoBehaviour
{
    public string[] data_player;
    public void datos_player(string[] data)
    {
        DontDestroyOnLoad(gameObject);
        data_player = data;
    }
}
