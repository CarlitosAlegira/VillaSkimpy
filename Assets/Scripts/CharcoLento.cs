using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoLento : MonoBehaviour
{
    // Start is called before the first frame update
    public bool collEnter = false, collExit = false, boom;
    GameObject gg;
    float Tiempo = 0;
    void Start()
    {
        gg = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 6.5f);
        Tiempo = Tiempo + 1 * Time.deltaTime;
        if (collEnter && Tiempo >= 6.0f)
        {
            gg.GetComponent<Movimeinto>().velocidad = gg.GetComponent<Movimeinto>().velocidad * 2.0f;
            Tiempo = 0;
        }
       // Debug.Log(gg);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("dentro trigger: "+other);
        if (other.tag == "Player")
        {
            collEnter = true;
            collExit = false;
            gg.GetComponent<Movimeinto>().velocidad = gg.GetComponent<Movimeinto>().velocidad /2.0f;
            //Debug.Log("Velocidad Entra: " + gg.GetComponent<Movimeinto>().velocidad);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            collExit = true;
            collEnter = false;
            gg.GetComponent<Movimeinto>().velocidad = gg.GetComponent<Movimeinto>().velocidad * 2.0f;
           // Debug.Log("Velocidad Sale: " + gg.GetComponent<Movimeinto>().velocidad);
        }
    }
}
