using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datos_bosque : MonoBehaviour
{
    public GameObject campo1, campo2, campo3, campo4,campo5;
    int f1, f2, f3, f4,f5;
    public float tiempo;
    void Start()
    {
        tiempo = GameObject.Find("Datos_player").GetComponent<Datos>().t1;
        f1 = GameObject.Find("Datos_player").GetComponent<Datos>().bosque[0];
        f2 = GameObject.Find("Datos_player").GetComponent<Datos>().bosque[1];
        f3 = GameObject.Find("Datos_player").GetComponent<Datos>().bosque[2];
        f4 = GameObject.Find("Datos_player").GetComponent<Datos>().bosque[3];
        f5 = GameObject.Find("Datos_player").GetComponent<Datos>().bosque[4];

        zonas_activas();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
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
        if (f5==1)
        {
            campo5.SetActive(false);
        }
    }
}
