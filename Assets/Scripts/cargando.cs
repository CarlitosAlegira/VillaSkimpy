using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargando : MonoBehaviour
{
    public Camera sec;
    private void Awake()
    {
        sec.enabled = true;
    }
    void Start()
    {
        string nivel_carga = Cargar_nivel.siguiente_nivel;
        StartCoroutine(this.Hacer_carga(nivel_carga));
    }

    IEnumerator Hacer_carga(string zona)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(zona);
        while (operacion.isDone==false)
        {
            yield return null;
        }
    }
}
