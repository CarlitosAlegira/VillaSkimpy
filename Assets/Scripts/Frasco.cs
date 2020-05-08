using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frasco : MonoBehaviour
{
    // Start is called before the first frame update
    public bool coll = false;
    GameObject gg, gg2;
    public GameObject CharcoLentitud;
    float velocidad = 80;
    void Start()
    {
        gg = GameObject.Find("Canvas_base");
        gg2 = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (coll == true)
        {
            Destroy(gameObject, .1f);
        }
        else
        {
            // transform.Translate(0, 0, .5f);
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * velocidad);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Tierra" )
        {
            if (other.tag == "Player")
            {
                coll = true;
                //Disminuir velocidad del player
            }
            else
            {
                coll = true;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
               // Debug.Log("charco");
                Instantiate(CharcoLentitud, transform.position, Quaternion.LookRotation(new Vector3(0, 0, 0)));
            }
        }
    }
}
