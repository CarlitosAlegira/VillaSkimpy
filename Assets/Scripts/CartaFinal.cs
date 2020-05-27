using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaFinal : MonoBehaviour
{

    public Canvas cartaFinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                cartaFinal.enabled = true;
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
    }

}
