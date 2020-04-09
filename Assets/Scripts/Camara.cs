using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject objetivo;
    public GameObject centro;
    public Vector3 distancia;
    public float vel, sensibilidad;
    
    Transform pos;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        pos=objetivo.GetComponent<Transform>();

    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,pos.position+distancia,vel);
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*sensibilidad,Vector3.up)* distancia;
        transform.LookAt(centro.transform);
    }
}
