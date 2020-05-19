using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida_centro1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Main").GetComponent<Camera>().enabled = false;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().act_desc_Hud();
            other.GetComponent<Inventario>().trans = false;
            Cargar_nivel.cargar("centro");
        }
    }
}
