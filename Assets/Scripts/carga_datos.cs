using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carga_datos : MonoBehaviour
{
    GameObject dato,jj;
    public GameObject j1, j2, j3;
    string nombre;
    float vida;
    int activa, a1, a2, a3, hero, zona;
    private void Start()
    {
        dato = GameObject.Find("carga");
        nombre = dato.GetComponent<carga_p>().data_player[0];
        vida=float.Parse(dato.GetComponent<carga_p>().data_player[1]);
        activa = int.Parse(dato.GetComponent<carga_p>().data_player[2]);
        a1 = int.Parse(dato.GetComponent<carga_p>().data_player[3]);
        a2= int.Parse(dato.GetComponent<carga_p>().data_player[4]);
        a3= int.Parse(dato.GetComponent<carga_p>().data_player[5]);
        hero = int.Parse(dato.GetComponent<carga_p>().data_player[6]);
        zona= int.Parse(dato.GetComponent<carga_p>().data_player[7]);
        GameObject.Find("Datos_player").GetComponent<Datos>().carga(nombre,hero);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().vida=vida;
        if (hero==1)
        {
            Destroy(j2);
            Destroy(j3);
            jj = j1;
        }
        else if (hero == 2)
        {
            Destroy(j1);
            Destroy(j3);
            jj = j2;
        }
        else if (hero == 3)
        {
            Destroy(j2);
            Destroy(j1);
            jj = j3;
        }

        if (a1==1)
        {
            jj.GetComponent<Inventario>().armas[1] = true;
        }
        if (a2 == 1)
        {
            jj.GetComponent<Inventario>().armas[2] = true;
        }
        if (a3 == 1)
        {
            jj.GetComponent<Inventario>().armas[3] = true;
        }


        Destroy(dato);
        Cargar_nivel.cargar("centro");
    }
}
