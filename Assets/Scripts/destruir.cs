using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    public bool dest;
    public GameObject particulas;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            if (dest && Input.GetKeyDown(KeyCode.E))
            {
                Instantiate(particulas,transform.position,particulas.transform.rotation);
                Destroy(gameObject,3);
            }
        }
    }
}
