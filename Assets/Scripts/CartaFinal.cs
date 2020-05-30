using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaFinal : MonoBehaviour
{

    public GameObject cartaFinal;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                cartaFinal.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void cargarEscenaFinal()
    {
        Cargar_nivel.cargar("Creditos");
    }

    public void MenuPrincipal()
    {
        Cargar_nivel.cargar("MenuPrincipal");
        Destroy(GameObject.Find("Datos_player"));
        Destroy(GameObject.Find("jugador"));
        Destroy(GameObject.Find("Canvas_base"));
    }

}
