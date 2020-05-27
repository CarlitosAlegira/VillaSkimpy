using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    // Start is called before the first frame update
    bool com1, com2, com3;
    public bool atack,run_atack,Running, dam1, dam2, dam3,rec_golpe,menu;
    float timer;
    Animator anim;
    int combo;
    public int Weapon;
    public GameObject wep1, wep2, wep3,wep4, inv,flecha,flecha_base;
    public AudioClip s_bat, s_axe, s_punch, s_maz;
    public AudioSource son;
    private float pox, poy;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        menu = gameObject.GetComponent<Movimeinto>().menu;
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
        if (pox!=0||poy!=0)
        {
            combo = 0;
        }
        if (Input.GetMouseButtonDown(0)&&Running && !rec_golpe&&!menu)
        {
            run_atack = true;
            run_animation();
        }
        if (Input.GetMouseButtonDown(0) && !run_atack && !rec_golpe && !menu)
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
        if (atack && !rec_golpe && !menu)
        {
            combat_system();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer>=0.5f)
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
            case 5:
                anim.SetBool("arco", true);
                break;
            default:
                anim.SetBool("punch", false);
                anim.SetBool("Hacha", false);
                anim.SetBool("Bate", false);
                anim.SetBool("Maza", false);
                anim.SetBool("arco", false);
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
                son.Play();
                break;
            case 2:
                dam1 = false;
                break;
            case 3:
                dam2 = true;
                son.Play();
                break;
            case 4:
                dam2 = false;
                break;
            case 5:
                dam3 = true;
                son.Play();
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
                wep4.SetActive(false);
                son.clip = s_bat;
                break;
            case 3:
                wep1.SetActive(false);
                wep2.SetActive(true);
                wep3.SetActive(false);
                wep4.SetActive(false);
                son.clip = s_axe;

                break;
            case 4:
                wep1.SetActive(false);
                wep2.SetActive(false);
                wep3.SetActive(true);
                wep4.SetActive(false);
                son.clip = s_maz;

                break;
            case 5:
                wep1.SetActive(false);
                wep2.SetActive(false);
                wep3.SetActive(false);
                wep4.SetActive(true);
                break;
            default:
                wep1.SetActive(false);
                wep2.SetActive(false);
                wep3.SetActive(false);
                wep4.SetActive(false);
                son.clip = s_punch;
                break;
        }
    }
    public void arco(int num)
    {
        switch (num)
        {
            case 1:
                flecha_base.SetActive(true);
                break;
            case 2:
                Instantiate(flecha,flecha_base.transform.position,flecha_base.transform.rotation);
                flecha_base.SetActive(false);
                atack = false;
                anim.SetBool("arco",false);
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="hacha")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().daño(10);
            GameObject.Find("Jaxon").GetComponent<boss1>().dm=false;
        }

        if (other.tag == "llave")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().daño(10);
            GameObject.Find("Mason").GetComponent<BossPetroleo>().dm = false;
        }

    }
}
