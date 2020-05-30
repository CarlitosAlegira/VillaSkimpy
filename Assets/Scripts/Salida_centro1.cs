using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida_centro1 : MonoBehaviour
{
    public GameObject minimapa;
    public GameObject datos_z;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.name == "Bosque")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().t1 = datos_z.GetComponent<datos_bosque>().tiempo;
            }
            else if (gameObject.name=="Caza")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().t2 = datos_z.GetComponent<datos_caza>().tiempo;
            }
            else if (gameObject.name=="Petroleo")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().t3 = datos_z.GetComponent<datos_petroleo>().tiempo;
            }
            minimapa.SetActive(false);
            GameObject.Find("Main").GetComponent<Camera>().enabled = false;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().act_desc_Hud();
            other.GetComponent<Inventario>().trans = false;
            Cargar_nivel.cargar("centro");
        }
    }
}
