using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void EmpezarNuevoJuego()
    {
        Cargar_nivel.cargar("intro");
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
    public void MenPrincipal()
    {
        Destroy(GameObject.Find("Canvas_base"));
        Destroy(GameObject.Find("jugador"));
        Destroy(GameObject.Find("Datos_player"));
        SceneManager.LoadScene("MenuPrincipal");
    }
}
