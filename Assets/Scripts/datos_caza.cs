﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datos_caza : MonoBehaviour
{
    public GameObject campo1, campo2, campo3, campo4;
    int f1, f2, f3, f4;
    void Start()
    {
        f1 = GameObject.Find("Datos_player").GetComponent<Datos>().caza[0];
        f2 = GameObject.Find("Datos_player").GetComponent<Datos>().caza[1];
        f3 = GameObject.Find("Datos_player").GetComponent<Datos>().caza[2];
        f4 = GameObject.Find("Datos_player").GetComponent<Datos>().caza[3];
        //f5 = GameObject.Find("Datos_player").GetComponent<Datos>().bosque[4];

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
            campo2.SetActive(false);
        }
        if (f3 == 1)
        {
            campo3.SetActive(false);
        }
        if (f4 == 1)
        {
            campo4.SetActive(false);
        }
        /*if (f5==1)
        {
            campo5.SetActive(false);
        }*/
    }
}
