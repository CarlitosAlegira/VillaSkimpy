using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogin : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void verificarLogin()
    {
        Debug.Log("Verificando Log in");
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void verificarRegistro()
    {
        Debug.Log("Verificando Registro");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }

}
