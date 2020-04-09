using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public GameObject h1,h2,h3,c1,c2,c3;
    GameObject datos,camara;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        camara = GameObject.Find("Main Camera");
        datos = GameObject.Find("Datos_player");
        if (datos.GetComponent<Datos>().hero == 1)
        {
            camara.GetComponent<Camara>().objetivo = h1;
            camara.GetComponent<Camara>().centro = c1;
            Destroy(h2);
            Destroy(h3);
        }
        else if (datos.GetComponent<Datos>().hero == 2)
        {
            camara.GetComponent<Camara>().objetivo = h2;
            camara.GetComponent<Camara>().centro = c2;
            Destroy(h1);
            Destroy(h3);
        }
        else if (datos.GetComponent<Datos>().hero == 3)
        {
            camara.GetComponent<Camara>().objetivo = h3;
            camara.GetComponent<Camara>().centro = c3;
            Destroy(h2);
            Destroy(h1);
        }
    }

}
