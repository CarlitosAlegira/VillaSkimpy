using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara2 : MonoBehaviour
{
    public GameObject objetivo, centro;
    public GameObject Datos_j, p1, p2, p3, c1, c2, c3;
    public Vector3 distancia1, distancia2;
    Vector3 prueba, mouse, posCam;
    public float sensibilidad;
    bool menu;
    Transform pos;
    private void Start()
    {
        objetivo = GameObject.Find("Heroe2");
        centro = GameObject.Find("c2");
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
                objetivo.transform.Rotate(0, -Input.GetAxisRaw("Mouse X") * sensibilidad, 0);
                transform.Rotate(Input.GetAxisRaw("Mouse Y") * sensibilidad, -Input.GetAxisRaw("Mouse X"), 0);
                transform.position = objetivo.transform.position + new Vector3(0, 1.4f, 0);
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
    public void asignar(int n)
    {
        prueba = distancia1;
        if (n == 1)
        {
            objetivo = p1;
            centro = c1;
        }
        else if (n == 2)
        {
            objetivo = p2;
            centro = c2;
        }
        else if (n == 3)
        {
            objetivo = p3;
            centro = c3;
        }
        pos = objetivo.GetComponent<Transform>();
    }
}
