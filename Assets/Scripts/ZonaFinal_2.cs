using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaFinal_2 : MonoBehaviour
{
    public Camera cinematica,basica;
    public GameObject cam,Arco;
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
            //este mostrar tiene que ir en la cinematica.
            //mostrar();
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
       //CINEMATICA
        cinematica.enabled = true;
        basica.enabled = false;
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
    }
    public void win()
    {
        // al dar click en el boton del canvas se ejecuta esto
        can_win.SetActive(false);
        Arco.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject);
    }
}
