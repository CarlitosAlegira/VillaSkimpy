using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nadar : MonoBehaviour
{
    public GameObject jugador;
    Animator anim;
    void Start()
    {
        anim = jugador.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="agua")
        {
            anim.SetBool("nadar", true);
            anim.SetBool("tierra", false);
            jugador.GetComponent<Movimeinto>().nadando = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="agua")
        {
            anim.SetBool("nadar", false);
            anim.SetBool("nadando", false);
            anim.SetBool("tierra", true);
            jugador.GetComponent<Movimeinto>().nadando = false;
        }
    }
}
