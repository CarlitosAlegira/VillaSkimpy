﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    GameObject objetivo;
    public GameObject hacha, tronco, encerrar,zona;
    bool empezar,saltar;
   //Vector3 distancia;
    float distancia;
    Animator anim;
    int at;
    void Start()
    {
        objetivo =GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.LookAt(objetivo.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (empezar)
        {
            distancia = Vector3.Distance(gameObject.transform.position, objetivo.transform.position);
            //Debug.Log(distancia);
            if (distancia <= 8)
            {
                at = Random.Range(1, 2);
                Debug.Log(at);
                anim.SetInteger("ataque", at);
                if (at == 1)
                {

                }
                else
                {

                }
            }
            else if (distancia >8 && distancia <20)
            {
                anim.SetInteger("ataque", 3);
            }
            else if (distancia >= 20)
            {
                anim.SetInteger("ataque", 4);
            }
        }
        if (saltar)
        {
            transform.Translate(0, 0, 10 * Time.deltaTime);
        }
    }

    public void mostrar()
    {
        hacha.SetActive(!hacha.activeInHierarchy);
    }
    public void cerrar()
    {
        encerrar.SetActive(!encerrar.activeInHierarchy);
        zona.GetComponent<ZonaFinal_1>().can.SetActive(false);
        objetivo.GetComponent<Inventario>().menus2 = false;
        objetivo.GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        comenzar();
    }
    public void comenzar()
    {
        empezar = true;
        anim.SetBool("start", true);
    }
    public void sal(int val)
    {
        if (val==1)
        {
            saltar = true;
        }
        else
        {
            saltar = false;
        }
    }
    public void mirar()
    {
        gameObject.transform.LookAt(objetivo.transform);
    }
    public void ter()
    {
        zona.GetComponent<ZonaFinal_1>().terminar();
    }
}
