using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_rock : MonoBehaviour
{
    public float vel=5;
    public GameObject par,b;
    bool move;
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            transform.Translate(0, 0, vel * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name!= "Jaxon")
        {
            b = Instantiate(par,gameObject.transform.position,par.transform.rotation);
            Destroy(b,2);
            Destroy(gameObject,2);
            move = true;
            if (collision.gameObject.tag == "Player")
            {
                GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().daño(20);
            }
        }
    }
}
