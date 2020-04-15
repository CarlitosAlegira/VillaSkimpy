using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    // Start is called before the first frame update
    bool com1, com2, com3;
    public bool atack,run_atack,Running, dam1, dam2, dam3,rec_golpe;
    float timer;
    Animator anim;
    int combo;
    public int Weapon;
    public GameObject wep1, wep2, wep3;
    private float pox, poy;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pox = Input.GetAxis("Horizontal");
        poy = Input.GetAxis("Vertical");
        changeweapon(Weapon);
        if (rec_golpe)
        {
            anim.SetBool("daño",true);
            anim.SetBool("quieto",false);
            animaciones_combate(0);
            atack = false;
        }
        else
        {
            anim.SetBool("daño",false);
        }
        if (Input.GetMouseButtonDown(0)&&Running && !rec_golpe)
        {
            run_atack = true;
            run_animation();
        }
        if (Input.GetMouseButtonDown(0) && !run_atack && !rec_golpe)
        {
            if (gameObject.GetComponent<Movimeinto>().agachado)
            {
                gameObject.GetComponent<Movimeinto>().slide();
            }
            combo += 1;
            if (combo>3)
            {
                combo = 3;
                if (com3)
                {
                    combo = 0;
                }
            }
            //Debug.Log(combo);
            atack = true;
        }
        if (atack && !rec_golpe)
        {
            combat_system();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer>=2)
            {
                gameObject.GetComponent<Movimeinto>().atacking = false;
                if (pox != 0 || poy != 0)
                {
                    anim.SetBool("caminar", true);
                    anim.SetBool("quieto", false);
                }
                else
                {
                    anim.SetBool("quieto", true);
                    anim.SetBool("caminar", false);
                }
                anim.SetBool("Combat", false);
                timer = 0;
            }
            else
            {

            }
        }
    }
    void combat_system()
    {
        if (Weapon==0)
        {
            Weapon = 1;
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
    void run_animation()
    {
        if (Weapon == 0)
        {
            Weapon = 1;
        }
        gameObject.GetComponent<Movimeinto>().atack_run = true;
        animaciones_combate(Weapon);
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
            case 4:
                anim.SetBool("Maza", true);
                break;
            default:
                anim.SetBool("punch", false);
                anim.SetBool("Hacha", false);
                anim.SetBool("Bate", false);
                anim.SetBool("Maza", false);
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
            case 8:
                gameObject.GetComponent<Movimeinto>().atacking = true;
                animaciones_combate(0);
                break;
            case 9:
                run_atack = false;
                gameObject.GetComponent<Movimeinto>().atack_run = false;
                gameObject.GetComponent<Movimeinto>().atacking = false;
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
                dam1 = false;
                break;
            case 3:
                dam2 = true;
                break;
            case 4:
                dam2 = false;
                break;
            case 5:
                dam3 = true;
                break;
            case 6:
                dam3 = false;
                break;
            default:
                break;
        }
    }
    void changeweapon(int num)
    {
        switch (num)
        {
            case 2:
                wep1.SetActive(true);
                wep2.SetActive(false);
                wep3.SetActive(false);
                break;
            case 3:
                wep1.SetActive(false);
                wep2.SetActive(true);
                wep3.SetActive(false);
                break;
            case 4:
                wep1.SetActive(false);
                wep2.SetActive(false);
                wep3.SetActive(true);
                break;
            default:
                wep1.SetActive(false);
                wep2.SetActive(false);
                wep3.SetActive(false);
                break;
        }
    }
}
