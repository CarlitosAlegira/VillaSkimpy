using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardo : MonoBehaviour
{
    // Start is called before the first frame update
    bool coll;
    GameObject gg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (coll)
        {
            //Destroy(gameObject, 0.5f);
        }
        else
        {
            transform.Translate(0, 0.2f, 0);
            //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        coll = true;
        transform.Translate(0, 0, 0);
        if (other.tag=="Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Canvas_jugador>().daño(10);
        }
    }
}
