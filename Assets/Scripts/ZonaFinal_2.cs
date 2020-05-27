using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaFinal_2 : MonoBehaviour
{
    public Camera cinematica,basica;
    public GameObject cam, Arco, MiniMap;
    public GameObject Dominic,canDialogo,can_win;
    Animator anim;
    bool f;
    void Start()
    {
        anim = cam.GetComponent<Animator>();

        basica = GameObject.Find("Main").GetComponent<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" && f)
        {
            canDialogo.SetActive(true);
            other.GetComponent<Inventario>().menus2 = true;
            other.GetComponent<Movimeinto>().menu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().Hub_mision.SetActive(false);
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().peligro.SetActive(false);
        }
    }
    void Update()
    {
        //Debug.Log(GameObject.Find("Datos_player").GetComponent<Datos>().progreso);
        if (GameObject.Find("Datos_player").GetComponent<Datos>().progreso== 4 && !f)
        {
            activar();
            f = true;
        }
    }
    void activar()
    {
        Debug.Log("entra al activar");
        cinematica.enabled = true;
        basica.enabled = false;
        MiniMap.SetActive(false);
        anim.SetBool("Entro",true);
    }
    public void mostrar()
    {
        Dominic.SetActive(true);
    }
    public void terminar()
    {
        cinematica.enabled = false;
        basica.enabled = true;
        MiniMap.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().aceptar_mision();
        //otro varios
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().varios(2);
    }
    public void win()
    {
        // al dar click en el boton del canvas se ejecuta esto
        can_win.SetActive(false);
        Arco.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().Hub_mision.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().peligro.SetActive(true);
        //un varios 
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().varios(4);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject);
    }
}
