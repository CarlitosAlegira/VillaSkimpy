using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaFinal_1 : MonoBehaviour
{
    public Camera cinematica,basica;
    public GameObject cam,hac,minimapa;
    public GameObject jaxon,can,can_win;
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
            can.SetActive(true);
            other.GetComponent<Inventario>().menus2 = true;
            other.GetComponent<Movimeinto>().menu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void Update()
    {
        if (GameObject.Find("Datos_player").GetComponent<Datos>().progreso==5 && !f)
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
        anim.SetBool("entro",true);
    }
    public void mostrar()
    {
        jaxon.SetActive(true);
    }
    public void terminar()
    {
        cinematica.enabled = false;
        basica.enabled = true;
        minimapa.SetActive(true);
    }
    public void win()
    {
        can_win.SetActive(false);
        hac.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject);
    }
}
