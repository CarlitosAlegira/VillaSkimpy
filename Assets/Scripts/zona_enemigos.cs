using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona_enemigos : MonoBehaviour
{
    public GameObject p_tala1, p_tala2, p_tala3, tienda,par1,par2,par3,par4;
    GameObject b1, b2, b3, b4;
    public int n_enemigos,dest,enemigos_base;
    bool p,p2,finish,entro;
    public AudioClip normal, zona_e,win;
    public AudioSource sonido_p,sonido_e;
    void Start()
    {
    }
    void Update()
    {
        if (!finish&&entro)
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_progreso(n_enemigos, enemigos_base);
        }
        if (n_enemigos >= enemigos_base && !p2)
        {
            p2 = true;
            p_tala1.GetComponent<destruir>().dest = true;
            p_tala2.GetComponent<destruir>().dest = true;
            p_tala3.GetComponent<destruir>().dest = true;
            tienda.GetComponent<destruir>().dest = true;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().terminar_zona();
            finish = true;
        }
        if (!p && dest >= 4)
        {
            p = true;
            parti();
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().prog_mision += 1;
            GameObject.Find("Datos_player").GetComponent<Datos>().progreso += 1;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().aceptar_mision();
            gameObject.SetActive(false);
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            if (gameObject.name== "Zona_enemigos1")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().bosque[0]=1;
            }
            else if (gameObject.name == "Zona_enemigos2")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().bosque[1] = 1;
            }
            else if(gameObject.name == "Zona_enemigos3")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().bosque[2] = 1;
            }
            else if(gameObject.name == "Zona_enemigos4")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().bosque[3] = 1;
            }
            else if(gameObject.name== "Zona_enemigos5")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().bosque[4]=1;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            if (!finish)
            {
                GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_progreso(n_enemigos, enemigos_base);
            }
            else
            {
                GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().terminar_zona();
            }
            if (sonido_p.clip == normal)
            {
                sonido_p.clip = zona_e;
                sonido_p.Play();
            }
            entro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            if (sonido_p.clip == zona_e)
            {
                sonido_p.clip = normal;
                sonido_p.Play();
            }

            entro = false;
        }
    }
    void parti()
    {
        b1 = Instantiate(par1, transform.position, par1.transform.rotation);
        Destroy(b1, 4);
        b2 = Instantiate(par2, transform.position, par2.transform.rotation);
        Destroy(b2, 4);
        b3 = Instantiate(par3, transform.position, par3.transform.rotation);
        Destroy(b3, 4);
        b4 = Instantiate(par4, transform.position, par4.transform.rotation);
        Destroy(b4, 8);
        if (sonido_e.clip != win)
        {
            sonido_e.clip = win;
            sonido_e.Play();
        }
    }
}
