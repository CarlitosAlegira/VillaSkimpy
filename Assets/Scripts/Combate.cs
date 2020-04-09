using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    // Start is called before the first frame update
    bool com1,com2,com3,dam1,dam2,dam3;
    public bool atack;
    float timer;
    Animator anim;
    int Weapon,combo;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            combo += 1;
            if (combo>3)
            {
                combo = 0;
            }
            //Debug.Log(combo);
            atack = true;
        }
        if (atack)
        {
            combat_system();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer>=2)
            {
                gameObject.GetComponent<Movimeinto>().atacking = false;
                anim.SetBool("Combat", false);
                timer = 0;
            }
        }
    }
    void combat_system()
    {
        if (Weapon==0)
        {
            Weapon = 3;
        }
        gameObject.GetComponent<Movimeinto>().atacking = true;
        anim.SetBool("Combat", true);
        if (!com1)
        {
            animaciones_combate(Weapon);
        }
        else
        {
            if (!com2 && combo>=2)
            {
                animaciones_combate(Weapon);
            }
            else
            {
                if (!com3 && combo==3)
                {
                    animaciones_combate(Weapon);
                }
                else
                {
                    animaciones_combate(0);
                    atack = false;
                    combo = 0;
                    com1 = false;
                    com2 = false;
                    com3 = false;
                }
            }
        }
    }
    void animaciones_combate(int num)
    {
        switch (num)
        {
            case 1:
                anim.SetBool("punch", true);
                break;
            case 2:
                anim.SetBool("Bate", true);
                break;
            case 3:
                anim.SetBool("Hacha", true);
                break;
            default:
                anim.SetBool("punch", false);
                anim.SetBool("Hacha", false);
                //anim.SetBool("Bate", false);
                break;
        }
    }
    void señales(int numero)
    {
        switch (numero)
        {
            case 1:
                //Debug.Log(com1);
                com1 = true;
                break;
            case 2:
                com2 = true;
                break;
            case 3:
                com3 = true;
                break;
            default:
                break;
        }
    }
    void damage(int valor)
    {
        switch (valor)
        {
            case 1:
                dam1 = true;
                break;
            case 2:
                dam2 = true;
                break;
            case 3:
                dam3 = true;
                break;
            default:
                break;
        }
    }
}
