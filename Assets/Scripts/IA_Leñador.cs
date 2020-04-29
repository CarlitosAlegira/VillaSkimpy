using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Lenador : MonoBehaviour
{
    enum state
    {
        IDLE, FOLLOW, ATTACK
    }


    NavMeshAgent agente;
    Animator anim;
    public GameObject heroe;
    public float distanciaAgente;
    public float distanciaSeguir;
    public float distanciaAtaque;
    private state currentState;
    void Start()
    {
        distanciaSeguir = 150;
        distanciaAtaque = 2;

        agente = GetComponent<NavMeshAgent>();
        heroe = GameObject.FindGameObjectWithTag("Player");
        currentState = state.IDLE;
    }

    void Update()
    {
        checkConditions();
        behaivor();
    }

    void behaivor()
    {
        switch (currentState)
        {
            case state.IDLE:
                idle();
                break;
            case state.FOLLOW:
                follow();
                break;
            case state.ATTACK:
                attack();
                break;
            default:
                break;
        }
    }

    void checkConditions()
    {
        distanciaAgente = Vector3.Distance(heroe.transform.position, transform.position);

        if (distanciaAgente < distanciaSeguir)
        {
            if (distanciaAgente < distanciaAtaque)
            {
                currentState = state.ATTACK;
            }
            else
            {
                currentState = state.FOLLOW;
            }
        }
        else
        {
            currentState = state.IDLE;
        }
    }

    void idle()
    {
        anim.SetBool("idleLenador", true);

        anim.SetBool("correrLenador", false);
        anim.SetBool("ataqueLenador", false);
        agente.SetDestination(transform.position);
        
    }

    void follow()
    {
        anim.SetBool("correrLenador", true);

        anim.SetBool("idleLenador", false);
        anim.SetBool("ataqueLenador", false);
        agente.SetDestination(heroe.transform.position);
    }

    void attack()
    {
        anim.SetBool("ataqueLenador", true);

        anim.SetBool("idleLenador", false);
        anim.SetBool("correrLenador", false);
        agente.SetDestination(transform.position);

    }

}
