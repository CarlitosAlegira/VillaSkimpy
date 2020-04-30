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
            Destroy(gameObject, 1.5f);
        }
        else
        {
            transform.Translate(0, 0, .5f);
            //gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        coll = true;
        if (other.tag=="Player")
        {
            transform.Translate(0, 0, 0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Canvas_jugador>().daño(10);
        }
    }
}
