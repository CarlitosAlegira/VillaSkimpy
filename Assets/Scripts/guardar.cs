using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            GameObject.Find("Datos_player").GetComponent<Datos>().nombre_save="Daniel1";
            GameObject.Find("Datos_player").GetComponent<Datos>().Guardar();
        }
    }
}
