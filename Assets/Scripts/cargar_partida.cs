using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cargar_partida : MonoBehaviour
{
    public GameObject pref,b;
    string datos_paso;
    //public TextMeshProUGUI partida;
    private void Start()
    {
        string añadir = PlayerPrefs.GetString("Partidas");
        string[] nombres_p = añadir.Split(",".ToCharArray());
        for (int i = 0; i < nombres_p.Length; i++)
        {
            
            string prueba = PlayerPrefs.GetString(nombres_p[i], "none");
            Debug.Log(prueba);
            if (prueba != "none")
            {
                string[] datos = prueba.Split(",".ToCharArray());
                datos_paso = datos[0];

                b = Instantiate(pref) as GameObject;
                b.GetComponent<data_prefab>().datos(datos_paso);
                b.GetComponent<data_prefab>().datos_player(datos);
                b.transform.parent = gameObject.transform;
            }
        }
    }
}
