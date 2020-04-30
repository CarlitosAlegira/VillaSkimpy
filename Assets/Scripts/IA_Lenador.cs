using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Lenador: MonoBehaviour
{
    // Start is called before the first frame update
    enum Stados
    {
        IDLE, FOLLOW, ATTACK
    }
    public float vida, VidaMax;
    //public float TamañoBarra;
    Stados currentstate;
    public Animator anim;
    NavMeshAgent nav1;
    public GameObject objetivo, ParticulaDaño, BarraVida;
    public ParticleSystem Particula;
    public float disActual, disReferencia, disReferencia2;
    void Start()
    {
        VidaMax = 200f;
        vida = 150f;
        objetivo = GameObject.FindGameObjectWithTag("Player");
        nav1 = GetComponent<NavMeshAgent>();
        disReferencia = 10;
        disReferencia2 = 1.5f;
        currentstate = Stados.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        behaviour();
        checkConditions();
        float z = vida /VidaMax;
        Vector3 EscalaBarra = new Vector3(1, 1, z);
        BarraVida.transform.localScale = EscalaBarra;
        Debug.Log("vida actual:" + z);
    }

    void checkConditions()
    {
        disActual = Vector3.Distance(objetivo.transform.position, transform.position);
        if (disActual <= disReferencia)
        {
            if (disActual <= disReferencia2)
            {
                currentstate = Stados.ATTACK;
            }
            else
            {
                currentstate = Stados.FOLLOW;
            }
        }
        else
        {
            currentstate = Stados.IDLE;
        }
    }
    void behaviour()
    {
        switch (currentstate)
        {
            case Stados.IDLE:
                idle();
                break;
            case Stados.FOLLOW:
                follow();
                break;
            case Stados.ATTACK:
                attack();
                break;
            default:
                break;
        }
    }
    void idle()
    {
        DarDaño(2);
        anim.SetBool("Quieto", true);
        anim.SetBool("Camina", false);
        anim.SetBool("Ataque", false);
        nav1.SetDestination(transform.position);
    }
    void follow()
    {
        DarDaño(2);
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", true);
        anim.SetBool("Ataque", false);
        nav1.SetDestination(objetivo.transform.position);
    }
    void attack()
    {
        //Debug.Log("atacar");
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", false);
        anim.SetBool("Ataque", true);
        nav1.SetDestination(transform.position);
        
    }
    void morido()
    {
        if (vida<=0)
        {
            vida = 0;
        }
    }
    public void DarDaño(int s)
    {
        if (s==1)
        {
            objetivo.GetComponent<Combate>().rec_golpe = true;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().daño(20f);
        }
        else if (s==2)
        {
            objetivo.GetComponent<Combate>().rec_golpe = false;
        }
    }
    public void RecibeDaño(float nim)
    {
        Instantiate(ParticulaDaño, gameObject.transform.position + new Vector3(0,0.5f,0), transform.rotation);
        //poner animacion de daño al enemigo
        anim.SetBool("Ddaño", true);
        vida -= nim;
    }
    public void desactivar()
    {
        anim.SetBool("Ddaño", false);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        { 
            if (other.GetComponent<Combate>().dam1)
            {
                RecibeDaño(15);
            }
            else if (other.GetComponent<Combate>().dam2)
            {
                RecibeDaño(15);
            }
            else if (other.GetComponent<Combate>().dam3)
            {
                RecibeDaño(15);
            }
            else
            {
            }
        }
    }


}
