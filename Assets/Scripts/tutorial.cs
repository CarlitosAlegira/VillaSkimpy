using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject  tuto;
    bool cancel;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player") && GameObject.Find("Datos_player").GetComponent<Datos>().mision == 0 && !cancel)
        {
            tuto.SetActive(true);
            cancel = true;
            other.GetComponent<Inventario>().menus2 = true;
            other.GetComponent<Movimeinto>().menu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void cerrar()
    {
        tuto.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
