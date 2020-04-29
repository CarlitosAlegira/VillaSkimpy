using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiones : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject.name == "mision1")
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text.text = "Hey veo que has vuelto me alegra mucho.\n Pero bueno vamos al grano. \n \n Hace ya algun tiempo hemos visto que el tamaño de nuestro bosque ha disminuido considerablemente por culpa de unos peligrosos leñadore. \n \n Ve e inestiga y lebera el bosque de esos terribles leñadores";
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().barra_vida.SetActive(false);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().showarm.SetActive(false);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }
            }
        }
    }
    public void aceptar()
    {
        salir();
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().Hub_mision.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text2.text="Investiga el Bosque";
    }
    public void salir()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text.text = " ";
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(false);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().barra_vida.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().showarm.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            salir();
        }
    }
}
