﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida_zona2 : MonoBehaviour
{
    public GameObject mostrar;
    bool si,no,is_menu;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player" && !is_menu)
        {
            mostrar.SetActive(true);
            other.GetComponent<Inventario>().menus2 = true;
            other.GetComponent<Movimeinto>().menu = true;
            Cursor.lockState = CursorLockMode.None;
            
            if (si)
            {
                GameObject.Find("Datos_player").GetComponent<Datos>().zona=2;
                mostrar.SetActive(false);
                other.GetComponent<Inventario>().menus2 = false;
                other.GetComponent<Movimeinto>().menu = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cargar_nivel.cargar("Cazadores");
                si = false;
                no = false;
                is_menu = true;
            }
            else if(no)
            {
                mostrar.SetActive(false);
                other.GetComponent<Inventario>().menus2 = false;
                other.GetComponent<Movimeinto>().menu = false;
                Cursor.lockState = CursorLockMode.Locked;
                si = false;
                no = false;
                is_menu = true;
            }
        }
    }
    
    public void respuesta(bool res)
    {
        if (res)
        {
            si = true;
        }
        else
        {
            no = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mostrar.SetActive(false);
            si = false;
            no = false;
            Cursor.lockState = CursorLockMode.Locked;
            is_menu = false;
        }
    }
}
