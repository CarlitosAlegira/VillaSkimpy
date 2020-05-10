using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaFinal_1 : MonoBehaviour
{
    public Camera cinematica,basica;
    public GameObject cam;
    public GameObject jaxon,can;
    Animator anim;
    bool f;
    void Start()
    {
        anim = cam.GetComponent<Animator>();
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
        Debug.Log(GameObject.Find("Datos_player").GetComponent<Datos>().progreso);
        if (GameObject.Find("Datos_player").GetComponent<Datos>().progreso==5 && !f)
        {
            activar();
            f = true;
        }
    }
    void activar()
    {
        cinematica.enabled = true;
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
    }
}
