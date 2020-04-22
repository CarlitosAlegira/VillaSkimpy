using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargando : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string nivel_carga = Cargar_nivel.siguiente_nivel;
        StartCoroutine(this.Hacer_carga(nivel_carga));
    }

    IEnumerator Hacer_carga(string zona)
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation operacion = SceneManager.LoadSceneAsync(zona);
        while (operacion.isDone==false)
        {
            yield return null;
        }
    }
}
