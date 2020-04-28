using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour
{
    GameObject objetivo, centro, Datos_j;
    public Vector3 distancia1, distancia2;
    Vector3 prueba,mouse,posCam;
    public float sensibilidad;
    public Camera cam;
    bool menu;
    Transform pos;
    private void Start()
    {
        prueba = distancia1;
        Datos_j = GameObject.Find("Datos_player");
        if (Datos_j.GetComponent<Datos>().hero == 1)
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
        else if (Datos_j.GetComponent<Datos>().hero == 3)
        {
            objetivo = GameObject.Find("Heroe3");
            objetivo.GetComponent<Movimeinto>().camaraP = cam;
            centro = GameObject.Find("c3");
        }

        pos = objetivo.GetComponent<Transform>();
    }
    void LateUpdate()
    {
        menu = objetivo.GetComponent<Movimeinto>().menu;
        if (!menu)
        {
            if (Input.GetMouseButton(1) && objetivo.GetComponent<Inventario>().Active == 5)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

                //prueba += mouse * sensibilidad;
                //prueba.y = Mathf.Clamp(prueba.y, -70, 70);
                objetivo.transform.Rotate(0, Input.GetAxisRaw("Mouse X")*sensibilidad,0);
                transform.Rotate(Input.GetAxisRaw("Mouse Y")*sensibilidad, 0, 0);
                transform.position = objetivo.transform.position + distancia2;
            }
            else
            {
                mouse.Set(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse ScrollWheel"));
                prueba += mouse * sensibilidad;
                prueba.z = Mathf.Clamp(prueba.z, -4, 0);
                prueba.y = Mathf.Clamp(prueba.y, -70, 70);
                posCam = Quaternion.AngleAxis(prueba.x, Vector3.up) * Quaternion.AngleAxis(prueba.y, Vector3.right) * Vector3.forward;
                posCam *= prueba.z * 1f;
                posCam += centro.transform.position;
                transform.position = posCam;
                transform.LookAt(centro.transform.position);
            }
        }
    }
}
