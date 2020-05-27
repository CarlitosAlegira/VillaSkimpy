using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carga_datos : MonoBehaviour
{
    GameObject dato,jj;
    public GameObject j1, j2, j3,datos,cam,c1,c2,c3;
    string nombre;
    float vida;
    int activa, a1, a2, a3,a4, hero;

    private void Start()
    {
        dato = GameObject.Find("carga");
        nombre = dato.GetComponent<carga_p>().data_player[0];
        vida=float.Parse(dato.GetComponent<carga_p>().data_player[1]);
        //activa = int.Parse(dato.GetComponent<carga_p>().data_player[2]);
        a1 = int.Parse(dato.GetComponent<carga_p>().data_player[3]);
        a2= int.Parse(dato.GetComponent<carga_p>().data_player[4]);
        a3= int.Parse(dato.GetComponent<carga_p>().data_player[5]);
        a4 = int.Parse(dato.GetComponent<carga_p>().data_player[6]);
        hero = int.Parse(dato.GetComponent<carga_p>().data_player[8]);
        datos.GetComponent<Datos>().mision = int.Parse(dato.GetComponent<carga_p>().data_player[9]);
        datos.GetComponent<Datos>().progreso = int.Parse(dato.GetComponent<carga_p>().data_player[10]);
        datos.GetComponent<Datos>().bosque[0]= int.Parse(dato.GetComponent<carga_p>().data_player[11]);
        datos.GetComponent<Datos>().bosque[1] = int.Parse(dato.GetComponent<carga_p>().data_player[12]);
        datos.GetComponent<Datos>().bosque[2] = int.Parse(dato.GetComponent<carga_p>().data_player[13]);
        datos.GetComponent<Datos>().bosque[3] = int.Parse(dato.GetComponent<carga_p>().data_player[14]);
        datos.GetComponent<Datos>().bosque[4] = int.Parse(dato.GetComponent<carga_p>().data_player[15]);
        datos.GetComponent<Datos>().caza[0] = int.Parse(dato.GetComponent<carga_p>().data_player[16]);
        datos.GetComponent<Datos>().caza[1] = int.Parse(dato.GetComponent<carga_p>().data_player[17]);
        datos.GetComponent<Datos>().caza[2] = int.Parse(dato.GetComponent<carga_p>().data_player[18]);
        datos.GetComponent<Datos>().caza[3] = int.Parse(dato.GetComponent<carga_p>().data_player[19]);
        datos.GetComponent<Datos>().petroleo[0] = int.Parse(dato.GetComponent<carga_p>().data_player[20]);
        datos.GetComponent<Datos>().petroleo[1] = int.Parse(dato.GetComponent<carga_p>().data_player[21]);
        datos.GetComponent<Datos>().petroleo[2] = int.Parse(dato.GetComponent<carga_p>().data_player[22]);
        datos.GetComponent<Datos>().petroleo[3] = int.Parse(dato.GetComponent<carga_p>().data_player[23]);
        datos.GetComponent<Datos>().petroleo[4] = int.Parse(dato.GetComponent<carga_p>().data_player[24]);
        datos.GetComponent<Datos>().petroleo[5] = int.Parse(dato.GetComponent<carga_p>().data_player[25]);
        Debug.Log(hero);
        datos.GetComponent<Datos>().carga(nombre,hero);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().vida=vida;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().puntos= int.Parse(dato.GetComponent<carga_p>().data_player[26]);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().prog_mision = int.Parse(dato.GetComponent<carga_p>().data_player[10]);
        if (int.Parse(dato.GetComponent<carga_p>().data_player[10]) != 0)
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().tip_mision = int.Parse(dato.GetComponent<carga_p>().data_player[9])+3;
        }
        else
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().tip_mision = int.Parse(dato.GetComponent<carga_p>().data_player[9]);
        }
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().puntaje(0);
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().actv_ms();
        
        if (hero==1)
        {
            cam.GetComponent<Camara2>().objetivo = j1;
            cam.GetComponent<Camara2>().centro = c1;
            Destroy(j2);
            Destroy(j3);
            jj = j1;
        }
        else if (hero == 2)
        {
            cam.GetComponent<Camara2>().objetivo = j2;
            cam.GetComponent<Camara2>().centro = c2;
            Destroy(j1);
            Destroy(j3);
            jj = j2;
        }
        else if (hero == 3)
        {
            cam.GetComponent<Camara2>().objetivo = j3;
            cam.GetComponent<Camara2>().centro = c3;
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
        if (a4 == 1)
        {
            jj.GetComponent<Inventario>().armas[4] = true;
        }


        Destroy(dato);
        Cargar_nivel.cargar("centro");
    }
}
