using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cine_events : MonoBehaviour
{
    public GameObject final;
    public void evento()
    {
        final.GetComponent<ZonaFinal_1>().mostrar();
    }
}
