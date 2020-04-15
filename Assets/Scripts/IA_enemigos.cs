using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_enemigos : MonoBehaviour
{
    public bool collision, enemi_see;
    bool girando, getpunch1, getpunch2, getpunch3, pegar,atacking,golpear,golpe_aval;
    float tiempo,timer1,velocidad;
    public Transform Punto_p;
    public GameObject objetivo;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Player");
        anim=gameObject.GetComponent<Animator>();
        Punto_p = objetivo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemi_see)
        {
            velocidad = 3;
            transform.LookAt(new Vector3(Punto_p.position.x, transform.position.y, Punto_p.position.z));
        }
        if (atacking)
        {
            timer1 += Time.deltaTime;
            if (timer1>=2)
            {
                golpear = true;
                timer1 = 0;
            }
            if (golpear && golpe_aval)
            {
                anim.SetBool("atack", true);
            }
        }
        if (!collision)
        {
            tiempo += 1 * Time.deltaTime;
            if (tiempo >= 1)
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
        }
        else
        {
            anim.SetBool("caminar", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            atacking = true;
            golpear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            golpe_aval = true;
            Punto_p = GameObject.FindGameObjectWithTag("Player").transform;
            collision = true;
            getpunch1 = other.GetComponent<Combate>().dam1;
            getpunch2 = other.GetComponent<Combate>().dam2;
            getpunch3 = other.GetComponent<Combate>().dam3;
            other.transform.LookAt(gameObject.transform);
            pegar = true;
            if (getpunch1)
            {
                timer1 = 0;
                anim.SetBool("punch", true);
                anim.SetBool("noAtack", false);
            }
            else if (getpunch2)
            {
                timer1 = 0;
                anim.SetBool("punch", true);
                anim.SetBool("noAtack", false);
            }
            else if (getpunch3)
            {
                timer1 = 0;
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
        atacking = false;
        collision = false;
        golpe_aval = false;
        anim.SetBool("noAtack", true);
    }
    void atack(int num)
    {
        switch (num)
        {
            case 1:
                golpear = false;
                anim.SetBool("atack",false);
                break;
            case 2:
                objetivo.GetComponent<Combate>().rec_golpe = true;
                break;
            case 3:
                objetivo.GetComponent<Combate>().rec_golpe = false;
                break;
            default:
                break;
        }
    }
}
