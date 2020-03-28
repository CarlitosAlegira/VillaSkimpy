using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_move : MonoBehaviour
{
    public float tiempo,velocidad;
    public bool collision;
    bool girando,getpunch,atack;
    Animator anim;
    float y,timer;
    private void Start()
    {
        anim=gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (!collision)
        {
            tiempo += 1 * Time.deltaTime;
            if (tiempo>=1)
            {
                transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
                transform.transform.Rotate(new Vector3(0, y, 0));
                anim.SetBool("caminar", true);
            }
            else
            {
                anim.SetBool("caminar", false);
            }
            if (tiempo >= Random.Range(5, 30))
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
            }
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
        collision = true;
        if (other.tag=="Player")
        {
            getpunch=other.GetComponent<Movimeinto>().ataking;
            if (getpunch)
            {
                timer += 1 * Time.deltaTime;
                if (timer>=0.4)
                {
                    timer = 0;
                    anim.SetBool("punch", true);
                    anim.SetBool("noAtack", false);
                }
            }
            else
            {
                anim.SetBool("punch", false);
                timer = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        collision = false;
        anim.SetBool("noAtack",true);
        timer = 0;
    }
}
