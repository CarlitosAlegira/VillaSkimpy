using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misiones : MonoBehaviour
{
    string mis;
    int m, p;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            m=GameObject.Find("Datos_player").GetComponent<Datos>().mision;
            p=GameObject.Find("Datos_player").GetComponent<Datos>().progreso;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject.name == "mision1")
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    mis= "Hey veo que has vuelto me alegra mucho.\nPero bueno vamos al grano. \n \nHace ya algun tiempo hemos visto que el tamaño de nuestro bosque ha disminuido considerablemente por culpa de unos peligrosos leñadores. \n \nVe e investiga y libera el bosque de esos terribles leñadores";
                    GameObject.Find("Datos_player").GetComponent<Datos>().mision=1;
                    GameObject.Find("Datos_player").GetComponent<Datos>().progreso = 0;
                    pon_mision(mis,1);
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }
                else if (gameObject.name=="mision2") /*&& m==1 && p==5*/ //este comentario es de sergio)
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    mis= "Hey hola veo que ya has liberado nuestros bosque de esos malvados leñadores.\n Pero bueno tu labor aun no esta terminada. \n \nHemos visto merodeando unos cazadores y nos dimos cuenta de que nuestros animales han desaparecido investiga la zona de las montañas y liberalos";
                    pon_mision(mis,2);
                    GameObject.Find("Datos_player").GetComponent<Datos>().mision = 2;
                    GameObject.Find("Datos_player").GetComponent<Datos>().progreso = 0;
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }
                else if (gameObject.name == "mision3" /*&& m == 2 && p == 6*/)
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    mis = "Hey hola veo que ya has resuelto la mayoria de nuestros problemas.\nPero aun te nesesitamos. \n \nDese hace ya un tiempo nos percatamos de que el agua del lago de la cual bebemos estaba sucia y tenia un sabor extraño.\nPodrias ir a revisar el lago";
                    pon_mision(mis, 3);
                    GameObject.Find("Datos_player").GetComponent<Datos>().mision = 3;
                    GameObject.Find("Datos_player").GetComponent<Datos>().progreso = 0;
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }
                else
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    error_mision();
                }


                if (gameObject.name == "misiones1")
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    mis = "Hey hola veo que vienes del pueblo.\nTe tengo que advertir que en esta zona hay varios grupos de leñadores que estan acabando con nuestro bosque. \n \nSi nos quieres ayudar podrias empezar destruyendo los puestos de tala";
                    pon_mision(mis, 4);
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }

                if (gameObject.name == "misiones2")
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    mis="Hey hola veo que vienes del pueblo.\nTe tengo que advertir que en esta zona hay varios grupos de cazadores que estan secuestrando a nuestros animales. \n \nSi nos quieres ayudar podrias liberarlos";
                    pon_mision(mis, 5);
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
                }

                if (gameObject.name == "misiones3")
                {
                    other.GetComponent<Movimeinto>().menu = true;
                    other.GetComponent<Inventario>().menus2 = true;
                    mis="Hey hola veo que vienes del pueblo.\nTe tengo que advertir que en esta zona hay extractoras de petroleo y estan siendo vigiladas constantemente. \n \nSi nos quieres ayudar podrias destruir las extractoras";
                    pon_mision(mis, 6);
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().des.SetActive(true);
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
    void pon_mision(string m,int tip)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text.text = m;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().barra_vida.SetActive(false);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().showarm.SetActive(false);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().tip_mision = tip;
    }
    void error_mision()
    {
        mis = "Hum por el momento no tengo nada que pedirte\nPero puedes busca a alguno de los otros aldeanos \nTal vez ellos nesesiten ayuda\nO puedes regresar mas tarde puede que tenga alguna tarea para ti";
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_text.text = mis;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().tip_mision = 10;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().C_mision.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().barra_vida.SetActive(false);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().showarm.SetActive(false);
    }
}
