using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cargar_partida : MonoBehaviour
{
    public GameObject pref,b;
    //public TextMeshProUGUI partida;
    private void Start()
    {
        string prueba = PlayerPrefs.GetString("Daniel1", "none");
        if (prueba != "none")
        {
            //partida.text ="daniel";

            b = Instantiate(pref) as GameObject;
            b.transform.parent = gameObject.transform;
        }
    }
}
