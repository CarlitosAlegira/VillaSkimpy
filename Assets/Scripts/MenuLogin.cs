using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log("LogIn Verificado");
        SceneManager.LoadScene("MenuPrincipal");

    }

    public void verificarRegistro()
    {
        Debug.Log("Registro Verificado");
        SceneManager.LoadScene("MenuLogin");

    }


    public void salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }

}
