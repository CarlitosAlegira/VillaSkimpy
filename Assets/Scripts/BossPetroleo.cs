using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPetroleo : MonoBehaviour
{
    GameObject objetivo;
    public GameObject hacha, roca_b, roca_i, encerrar, zona, bar_vida, correr, b;
    public Image barra;
    public bool dm,cont;
    bool empezar, saltar, habilitado, muerto, a1, a2, a3, aturdir, lanzar, huir;
    //Vector3 distancia;
    float distancia, salt_vel, vida, timer;
    Animator anim;
    int at;
    void Start()
    {
        habilitado = true;
        objetivo = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.LookAt(objetivo.transform);
        vida = 1000;
    }

    void Update()
    {
        barra.fillAmount = vida / 1000;
        if (empezar && !muerto && !aturdir)
        {
            distancia = Vector3.Distance(gameObject.transform.position, objetivo.transform.position);
            //Debug.Log(distancia);
            if (distancia <= 8)
            {
                lanzar = false;
                at = Random.Range(1, 2);
                if (at == 1)
                {
                    anim.SetInteger("ataque", 1);
                }
                else
                {
                    anim.SetInteger("ataque", 2);
                }
            }
            else if (distancia > 8 && distancia < 20)
            {
                lanzar = false;
                anim.SetInteger("ataque", 3);
            }
            else if (distancia >= 20 && !lanzar)
            {
                anim.SetInteger("ataque", 4);
            }
            else
            {
                mirar();
                anim.SetInteger("ataque", 0);
                gameObject.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            }
        }
        if (vida <= 0)
        {
            if (!cont)
            {
                GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().puntaje(1000);
                cont = true;
            }
            anim.SetBool("stun", true);
            anim.SetBool("muerte", true);
            muerto = true;
            if (huir)
            {
                ganar();
            }
        }
        if (aturdir)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                timer = 0;
                anim.SetBool("stun", false);
                aturdir = false;
            }
        }
        if (saltar)
        {
            transform.Translate(0, 0, salt_vel / 2 * Time.deltaTime);
        }
    }

    public void mostrar()
    {
        hacha.SetActive(!hacha.activeInHierarchy);
    }
    public void cerrar()
    {
        encerrar.SetActive(!encerrar.activeInHierarchy);
        zona.GetComponent<ZonaFinal_3>().can.SetActive(false);
        objetivo.GetComponent<Inventario>().menus2 = false;
        objetivo.GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        comenzar();
    }
    public void comenzar()
    {
        empezar = true;
        bar_vida.SetActive(true);
        anim.SetBool("start", true);
    }
    public void sal(int val)
    {
        mirar();
        if (val == 1)
        {
            saltar = true;
        }
        else
        {
            saltar = false;
        }
    }
    public void mirar()
    {
        gameObject.transform.LookAt(new Vector3(objetivo.transform.position.x, transform.position.y, objetivo.transform.position.z));
        salt_vel = distancia;
    }
    public void ter()
    {
        zona.GetComponent<ZonaFinal_3>().terminar();
    }
    public void damage(float dm)
    {
        vida -= dm;
        if (vida <= 775 && vida >= 725 && !a1)
        {
            anim.SetBool("stun", true);
            aturdir = true;
            a1 = true;
        }
        if (vida <= 525 && vida >= 475 && !a2)
        {
            anim.SetBool("stun", true);
            aturdir = true;
            a2 = true;
        }
        if (vida <= 275 && vida >= 225 && !a3)
        {
            anim.SetBool("stun", true);
            aturdir = true;
            a3 = true;
        }
    }
    public void ganar()
    {
        encerrar.SetActive(false);
        gameObject.transform.LookAt(new Vector3(correr.transform.position.x, transform.position.y, correr.transform.position.z));
        transform.Translate(0, 0, 5 * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= 7)
        {
            Destroy(gameObject);
            zona.GetComponent<ZonaFinal_3>().can_win.SetActive(true);
            objetivo.GetComponent<Inventario>().menus2 = true;
            objetivo.GetComponent<Movimeinto>().menu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void desactivar()
    {
        lanzar = true;
        hacha.SetActive(true);
        roca_b.SetActive(false);
    }
    public void activar()
    {
        hacha.SetActive(false);
        roca_b.SetActive(true);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if ((other.GetComponent<Combate>().dam1 || other.GetComponent<Combate>().dam2 || other.GetComponent<Combate>().dam3) && habilitado)
            {
                damage(500 * Time.deltaTime);
                //habilitado = false;
            }
        }
    }
    public void huyendo()
    {
        huir = true;
    }
    public void spawn_rock()
    {
        hacha.SetActive(false);
        roca_b.SetActive(false);
        b = Instantiate(roca_i, roca_b.transform.position, roca_b.transform.rotation);
        Destroy(b, 10);
    }
    public void ataque_damage(int val)
    {
        if (val == 1)
        {
            dm = true;
        }
    }
}
