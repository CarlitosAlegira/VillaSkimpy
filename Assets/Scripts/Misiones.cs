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
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text.text = "Hey veo que has vuelto me alegra mucho.\n Pero bueno vamos al grano. \n \n Hace ya algun tiempo hemos visto que el tamaño de nuestro bosque ha disminuido considerablemente por culpa de unos peligrosos leñadores. \n \n Ve e investiga y libera el bosque de esos terribles leñadores";
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().barra_vida.SetActive(false);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().showarm.SetActive(false);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().tip_mision = 1;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }
                if (gameObject.name=="mision2")
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text.text = "Hey hola veo que ya has liberado nuestros bosque de esos malvados leñadores.\n Pero bueno tu labor aun no esta terminada. \n \n hemos visto merodeando unos cazadores y nos dimos cuenta de que nuestros animales han desaparecido investiga la zona de las montañas y liberalos";
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().barra_vida.SetActive(false);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().showarm.SetActive(false);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().tip_mision = 2;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }


                if (gameObject.name == "misiones1")
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text.text = "Hey hola veo que vienes del pueblo.\n Te tengo que advertir que en esta zona hay varios grupos de leñadores que estan acabando con nuestro bosque. \n \n Si nos quieres ayudar podrias empezar destruyendo los puestos de tala";
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().barra_vida.SetActive(false);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().showarm.SetActive(false);
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().tip_mision = 4;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().rechazar_mision();
        }
    }
}
