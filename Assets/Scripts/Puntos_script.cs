using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform w1, w2, w3;
    int direccion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Aldeano"))
        {
            direccion = Random.Range(2, 30);
            if (direccion>=1 && direccion<=14)
            {
                other.GetComponent<IA_move>().Punto_p = w1;
            }
            else if (direccion > 14 && direccion <= 28)
            {
                other.GetComponent<IA_move>().Punto_p = w2;
            }
            else if (direccion > 28 && direccion <= 30)
            {
                other.GetComponent<IA_move>().Punto_p = w3;
            }

            other.GetComponent<IA_move>().collision = false;
        }
    }
}
