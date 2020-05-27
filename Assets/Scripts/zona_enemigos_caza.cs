﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona_enemigos_caza : MonoBehaviour
{
    public GameObject Jaula1, Jaula2, Jaula3, Jaula4, par1,par2,par3,par4;
    GameObject b1, b2, b3, b4;
    public int n_enemigos,dest,cuantodest,enemigos_base;
    bool p,p2,entro;
    public AudioClip normal, zona_e,win;
    public AudioSource sonido_p,sonido_e;
    void Start()
    {
    }
    void Update()
    {
        if (entro)
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_progreso(n_enemigos, enemigos_base);
            if (sonido_p.clip == normal)
            {
                sonido_p.clip = zona_e;
                sonido_p.Play();
            }
        }
        if (n_enemigos == enemigos_base && !p2)
        {
            
            //Debug.Log("habilitando abrir jaulas");
            Jaula1.GetComponent<AbrirJaula>().dest = true;
            Jaula2.GetComponent<AbrirJaula>().dest = true;
            Jaula3.GetComponent<AbrirJaula>().dest = true;
            Jaula4.GetComponent<AbrirJaula>().dest = true;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().terminar_zona();
            p2 = true;
            entro = false;
            //Debug.Log("Terminando if");
        }
        if (!p && dest >= cuantodest)
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().puntaje(500);
            p = true;
            //parti();
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().prog_mision += 1;
            GameObject.Find("Datos_player").GetComponent<Datos>().progreso += 1;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().aceptar_mision();
            //gameObject.SetActive(false);
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            //PONER LO QUE DICE HERMOSILLA
            if (gameObject.name == "Zona_1")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().caza[0] = 1;
            }
            else if (gameObject.name == "Zona_2")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().caza[1] = 1;
            }
            else if (gameObject.name == "Zona_3")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().caza[2] = 1;
            }
            else if (gameObject.name == "Zona_4")
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().caza[3] = 1;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            entro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            entro = false;
            if (sonido_p.clip == zona_e)
            {
                sonido_p.clip = normal;
                sonido_p.Play();
            }
        }
        gameObject.SetActive(false);
    }
    void parti()
    {
        /*b1 = Instantiate(par1, transform.position, par1.transform.rotation);
        Destroy(b1, 4);
        b2 = Instantiate(par2, transform.position, par2.transform.rotation);
        Destroy(b2, 4);
        b3 = Instantiate(par3, transform.position, par3.transform.rotation);
        Destroy(b3, 4);
        b4 = Instantiate(par4, transform.position, par4.transform.rotation);
        Destroy(b4, 8);*/
        if (sonido_e.clip != win)
        {
            sonido_e.clip = win;
            sonido_e.Play();
        }
    }
}
