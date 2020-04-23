using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public static bool pausa = false;
    public GameObject menuPausa;

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            continuar();
        }
        else
        {
            pausar();
        }

    }

    public void continuar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }

    void pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }

    public void irMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void salir()
    {
        Application.Quit();
    }
}
