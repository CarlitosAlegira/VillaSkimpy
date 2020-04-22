using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Cargar_nivel
{
    public static string siguiente_nivel;
    public static void cargar(string name)
    {
        siguiente_nivel = name;
        SceneManager.LoadScene("Carga");
    }
}
