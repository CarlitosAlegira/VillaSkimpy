using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_move : MonoBehaviour
{
    public float tiempo,velocidad, timer;
    public bool collision;
    bool girando,getpunch1, getpunch2, getpunch3,pegar;
    public Transform Punto_p,perseguir;
    Animator anim;
    float y;
    int direccion;
    private void Start()
    {
        anim=gameObject.GetComponent<Animator>();
        perseguir = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (pegar)
        {
            timer += Time.deltaTime;
            if (timer>=10)
            {
                anim.SetBool("noAtack",true);
                pegar = false;
                timer = 0;
            }
        }
        if (!collision)
        {
            if (pegar)
            {
                transform.LookAt(new Vector3(perseguir.position.x, transform.position.y, perseguir.position.z));
            }
            else
            {
                transform.LookAt(new Vector3(Punto_p.position.x, transform.position.y, Punto_p.position.z));
            }
            tiempo += 1 * Time.deltaTime;
            if (tiempo>=1)
            {
                transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
                //transform.transform.Rotate(new Vector3(0, y, 0));
                if (pegar)
                {
                    anim.SetBool("caminar", true);
                    anim.SetBool("noAtack", false);
                }
                else
                {
                    anim.SetBool("caminar", true);
                }
            }
            else
            {
                anim.SetBool("caminar", false);
            }
            /*if (tiempo >= Random.Range(5, 30))
            {
                girar();
                girando = true;
                tiempo = 0;
            }
            if (girando)
            {
                if (tiempo >= Random.Range(1, 5))
                {
                    y = 0;
                    girando = false;
                    tiempo = 0;
                }
            }*/
        }
        else
        {
            anim.SetBool("caminar", false);
        }

    }
    public void girar()
    {
        y = Random.Range(-3,3);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            collision = true;
            getpunch1 = other.GetComponent<Combate>().dam1;
            getpunch2 = other.GetComponent<Combate>().dam2;
            getpunch3 = other.GetComponent<Combate>().dam3;
            other.transform.LookAt(gameObject.transform);
            if (getpunch1)
            {
                timer = 0;
                pegar = true;
                anim.SetBool("punch", true);
                anim.SetBool("noAtack", false);
            }
            else if (getpunch2)
            {
                anim.SetBool("punch", true);
                anim.SetBool("noAtack", false);
            }
            else if (getpunch3)
            {
                anim.SetBool("punch", true);
                anim.SetBool("noAtack", false);
            }
            else
            {
                anim.SetBool("punch", false);
            }
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        collision = false;
        anim.SetBool("noAtack",true);
    }
}
