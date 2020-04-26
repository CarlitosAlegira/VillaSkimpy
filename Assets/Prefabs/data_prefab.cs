using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class data_prefab : MonoBehaviour
{
    public TextMeshProUGUI partida;
    string[] data_player;
    public void datos(string data)
    {
        partida.text = data;
    }
    public void datos_player(string[] data)
    {
        data_player = data;
    }
    public void cargar()
    {
        GameObject.Find("carga").GetComponent<carga_p>().datos_player(data_player);
        Cargar_nivel.cargar("paso_carga");
    }
}
