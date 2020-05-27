using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirJaula : MonoBehaviour
{
    public bool dest = false, JaulaAbierta = false;
    public GameObject particulas, zona, animal1, animal2, animal3, animal4, animal5, animal6, animal7;
    //GameObject b;
    public AudioClip exp;
    public AudioSource sonido;
    public Animator anim;
    public BoxCollider caja;
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("entrando al trigger");
        if (other.tag == "Player")
        {
            //Debug.Log("entrando al if de personaje");
            if (dest &&  Input.GetKeyDown(KeyCode.E))
            {
                
               // Debug.Log("entrando al if de abrir jaula");
                animal1.GetComponent<HuidaAnimal>().Encerrado = false;
                animal1.GetComponent<HuidaAnimal>().Huir = true;

                animal2.GetComponent<HuidaAnimal>().Encerrado = false;
                animal2.GetComponent<HuidaAnimal>().Huir = true;

                animal3.GetComponent<HuidaAnimal>().Encerrado = false;
                animal3.GetComponent<HuidaAnimal>().Huir = true;

                animal4.GetComponent<HuidaAnimal>().Encerrado = false;
                animal4.GetComponent<HuidaAnimal>().Huir = true;

                animal5.GetComponent<HuidaAnimal>().Encerrado = false;
                animal5.GetComponent<HuidaAnimal>().Huir = true;

                animal6.GetComponent<HuidaAnimal>().Encerrado = false;
                animal6.GetComponent<HuidaAnimal>().Huir = true;

                animal7.GetComponent<HuidaAnimal>().Encerrado = false;
                animal7.GetComponent<HuidaAnimal>().Huir = true;
                zona.GetComponent<zona_enemigos_caza>().dest += 1;
                zona.GetComponent<zona_enemigos_caza>().completeJ = true;
                caja.GetComponent<BoxCollider>().isTrigger = true;
                anim.SetBool("AbrirJaula", true);
                anim.SetBool("CerrarJaula", false);
                JaulaAbierta = true;
                dest = false;
                //sonido.clip = exp;
                //sonido.Play();
                //ACA VA LA VAINA PARA ABRIR LA JAULA
            }
        }
    }
}
