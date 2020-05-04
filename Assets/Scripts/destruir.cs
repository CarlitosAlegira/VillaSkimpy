using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    public bool dest;
    public GameObject particulas,zona;
    GameObject b;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            if (dest && Input.GetKeyDown(KeyCode.E))
            {
                b=Instantiate(particulas,transform.position,particulas.transform.rotation);
                Destroy(gameObject,2);
                Destroy(b, 4);
                zona.GetComponent<zona_enemigos>().dest += 1;
            }
        }
    }
}
