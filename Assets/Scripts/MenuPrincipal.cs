﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }
    public void EmpezarNuevoJuego()
    {
        Cargar_nivel.cargar("base");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
    public void MenPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
