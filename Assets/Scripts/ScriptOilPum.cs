using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOilPum : MonoBehaviour
{

    enum Stados
    {
        IDLE, ACCION
    }

    Stados currentstate;
    public Animator anim;
    void Start()
    {
        currentstate = Stados.ACCION;
    }

    void Update()
    {
        behaviour();
        checkConditions();
    }

    void checkConditions()
    {
        
    }
    void behaviour()
    {
        switch (currentstate)
        {
            case Stados.IDLE:
                idle();
                break;
            case Stados.ACCION:
                accion();
                break;
            default:
                break;
        }
    }
    void idle()
    {
        anim.SetBool("idleOil", true);
        anim.SetBool("accionOil", false);
        //Debug.Log("quieto");
    }
    void accion()
    {
        //Debug.Log("seguir");
        anim.SetBool("idleOil", false);
        anim.SetBool("accionOil", true);
    }

}
