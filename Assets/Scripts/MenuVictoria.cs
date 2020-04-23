using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuVictoria : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void irMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void juegoNuevo()
    {
        SceneManager.LoadScene("base");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
}
