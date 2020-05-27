using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir_petroleo : MonoBehaviour
{
    public bool dest;
    public GameObject particulas, zona;
    GameObject b;
    public AudioClip exp;
    public AudioSource sonido;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (dest && Input.GetKeyDown(KeyCode.E))
            {
                sonido.clip = exp;
                b = Instantiate(particulas, transform.position, particulas.transform.rotation);
                Destroy(gameObject, 2);
                Destroy(b, 4);
                zona.GetComponent<zona_enemigos_petroleo>().dest += 1;
                dest = false;
                sonido.Play();
            }
        }
    }
}
