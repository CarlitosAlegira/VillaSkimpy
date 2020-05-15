using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirJaula : MonoBehaviour
{
    public bool dest, JaulaAbierta = false;
    public GameObject particulas, zona;
    //GameObject b;
    public AudioClip exp;
    public AudioSource sonido;
    public Animator anim;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (dest &&  Input.GetKeyDown(KeyCode.E))
            {
                zona.GetComponent<zona_enemigos_caza>().dest += 1;
                dest = false;
                //sonido.clip = exp;
                //sonido.Play();
                //ACA VA LA VAINA PARA ABRIR LA JAULA
                anim.SetBool("AbrirJaula",true);
                anim.SetBool("CerJaularar", false);
                JaulaAbierta = true;
            }
        }
    }
}
