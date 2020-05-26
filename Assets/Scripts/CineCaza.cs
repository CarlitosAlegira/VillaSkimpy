using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineCaza : MonoBehaviour
{
    public GameObject final;
    public void evento()
    {
        final.GetComponent<ZonaFinal_2>().mostrar();
    }
    public void eventoT()
    {
        final.GetComponent<ZonaFinal_2>().terminar();
    }
}
