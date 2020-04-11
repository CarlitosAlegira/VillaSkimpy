using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    GameObject objetivo, centro, Datos_j;
    public Vector3 distancia;
    public float vel, sensibilidad;
    public Camera cam;
    Transform pos;
    private void Start()
    {
        Datos_j= GameObject.Find("Datos_player");
        if (Datos_j.GetComponent<Datos>().hero==1)
        {
            objetivo = GameObject.Find("Heroe1");
            objetivo.GetComponent<Movimeinto>().camaraP = cam;
            centro = GameObject.Find("c1");
        }
        else if (Datos_j.GetComponent<Datos>().hero == 2)
        {
            objetivo = GameObject.Find("Heroe2");
            objetivo.GetComponent<Movimeinto>().camaraP = cam;
            centro = GameObject.Find("c2");
        }
        else if(Datos_j.GetComponent<Datos>().hero == 3)
        {
            objetivo = GameObject.Find("Heroe3");
            objetivo.GetComponent<Movimeinto>().camaraP = cam;
            centro = GameObject.Find("c3");
        }
        
        pos = objetivo.GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,pos.position+distancia,vel);
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*sensibilidad,Vector3.up)* distancia;
        transform.LookAt(centro.transform);
    }
}
