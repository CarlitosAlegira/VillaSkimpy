using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida_centro1 : MonoBehaviour
{
    public GameObject minimapa;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            minimapa.SetActive(false);
            GameObject.Find("Main").GetComponent<Camera>().enabled = false;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().act_desc_Hud();
            other.GetComponent<Inventario>().trans = false;
            Cargar_nivel.cargar("centro");
        }
    }
}
