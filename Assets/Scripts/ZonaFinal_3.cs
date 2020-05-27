using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaFinal_3 : MonoBehaviour
{
    public Camera cinematica, basica;
    public GameObject cam, carta, minimapa;
    public GameObject Mason, can, can_win;
    Animator anim;
    bool f;
    void Start()
    {
        anim = cam.GetComponent<Animator>();

        basica = GameObject.Find("Main").GetComponent<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && f)
        {
            can.SetActive(true);
            other.GetComponent<Inventario>().menus2 = true;
            other.GetComponent<Movimeinto>().menu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void Update()
    {
        if (GameObject.Find("Datos_player").GetComponent<Datos>().progreso == 6 && !f)
        {
            activar();
            f = true;
        }
    }
    void activar()
    {
        cinematica.enabled = true;
        minimapa.SetActive(false);
        basica.enabled = false;
        anim.SetBool("CinePetroleo", true);
    }
    public void mostrar()
    {
        Mason.SetActive(true);
    }
    public void terminar()
    {
        cinematica.enabled = false;
        basica.enabled = true;
        minimapa.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().aceptar_mision();
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().varios(3);
    }
    public void win()
    {
        can_win.SetActive(false);
        carta.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().Hub_mision.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().peligro.SetActive(true);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().varios(4);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject);
    }
}
