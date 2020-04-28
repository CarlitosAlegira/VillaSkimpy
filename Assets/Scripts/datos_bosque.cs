using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datos_bosque : MonoBehaviour
{
    public GameObject campo1, campo2, campo3, campo4;
    int f1, f2, f3, f4;
    void Start()
    {
        zonas_activas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void zonas_activas()
    {
        if (f1 == 1)
        {
            campo1.SetActive(false);
        }
        if (f2 == 1)
        {
            campo1.SetActive(false);
        }
        if (f3 == 1)
        {
            campo1.SetActive(false);
        }
        if (f4 == 1)
        {
            campo1.SetActive(false);
        }
    }
}
