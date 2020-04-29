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
    Stados currentstate;
    public Animator anim;
    NavMeshAgent nav1;
    public GameObject objetivo;
    public ParticleSystem Particula;
    public float disActual, disReferencia, disReferencia2;
    void Start()
    {
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
        anim.SetBool("Quieto", true);
        anim.SetBool("Camina", false);
        anim.SetBool("Ataque", false);
        Debug.Log("quieto");
        nav1.SetDestination(transform.position);
    }
    void follow()
    {
        Debug.Log("seguir");
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", true);
        anim.SetBool("Ataque", false);
        nav1.SetDestination(objetivo.transform.position);
    }
    void attack()
    {
        Debug.Log("atacar");
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", false);
        anim.SetBool("Ataque", true);
        nav1.SetDestination(transform.position);
    }
    

}
