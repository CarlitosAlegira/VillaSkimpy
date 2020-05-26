using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cine_petroleo : MonoBehaviour
{
    public GameObject final;
    public void evento()
    {
        final.GetComponent<ZonaFinal_3>().mostrar();
    }
    /*public void eventoT()
    {
        final.GetComponent<ZonaFinal_3>().terminar();
    }*/
}
