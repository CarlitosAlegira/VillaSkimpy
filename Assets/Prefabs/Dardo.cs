using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardo : MonoBehaviour
{
    // Start is called before the first frame update
    public bool coll = false;
    GameObject gg, gg2;
    float velocidad = 90;
    void Start()
    {
        gg = GameObject.Find("Canvas_base");
        gg2 = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (coll==true)
        {
            Destroy(gameObject,1.5f);
        }
        else
        {
           // transform.Translate(0, 0, .5f);
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*velocidad);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            coll = true;
            //transform.Translate(0, 0, 0);
            gg.GetComponent<Canvas_jugador>().daño(8);
            //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*-velocidad);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //FALA HACER QUE EL DARDO SE QUEDE PEGADO AL PERSONAJE
            gameObject.transform.parent = gg2.transform;

        }
    }
}
