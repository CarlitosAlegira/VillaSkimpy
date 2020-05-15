using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Cazador: MonoBehaviour
{
    // Start is called before the first frame update
    enum Stados
    {
        IDLE, FOLLOW, ATTACKDISTANCE, ATTACKMELE
    }
    public float vida, VidaMax, delay, fireRate,XPos,YPos,Zpos;
    float time = 1.5f;
    //public float TamañoBarra;
    Stados currentstate;
    public Animator anim;
    NavMeshAgent nav1;
    public GameObject objetivo, ParticulaDaño, BarraVida, Dardo, DardoSpawn, Observador, Observando, Rifle, b;
    public ParticleSystem Particula;
    public float disActual, disReferencia, disReferencia2,disReferencia3;
    private Vector3 PosicionAMirar;
    bool habilitado = true, vivo = true,call;
    public GameObject zona;
    void Start()
    {
        delay = 1;
        fireRate = 1.5f;
        VidaMax = 200f;
        vida = 150f;
        objetivo = GameObject.FindGameObjectWithTag("Player");
        Observando = GameObject.FindGameObjectWithTag("Player");
        nav1 = GetComponent<NavMeshAgent>();
        disReferencia = 30;
        disReferencia2 = 8f;
        disReferencia3 = 1.85f;
        currentstate = Stados.IDLE;

    }

    // Update is called once per frame
    void Update()
    {
        if (vivo)
        {
            behaviour();
            checkConditions();
        }
        
        float z = vida /VidaMax;
        Vector3 EscalaBarra = new Vector3(1, 1, z);
        BarraVida.transform.localScale = EscalaBarra;
        if (vida <= 0)
        {
            vida = 0;
                if (!call)
                {
                 morido();
                 call = true;
                }
            
        }
    }

    void checkConditions()
    {
        if (vivo)
        {
            disActual = Vector3.Distance(objetivo.transform.position, transform.position);
            if (disActual <= disReferencia)
            {
                if (disActual <= disReferencia2)
                {
                    if (disActual <= disReferencia3)
                    {
                        currentstate = Stados.ATTACKMELE;
                    }
                    else
                    {
                        currentstate = Stados.ATTACKDISTANCE;
                    }
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
            case Stados.ATTACKDISTANCE:
                attackDistance();
                break;
            case Stados.ATTACKMELE:
                attackMele();
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
        anim.SetBool("Daño", false);
        anim.SetBool("Muerte", false);
        anim.SetBool("Cacha", false);
        nav1.SetDestination(transform.position);
    }
    void follow()
    {
        DarDaño(2);
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", true);
        anim.SetBool("Ataque", false);
        anim.SetBool("Daño", false);
        anim.SetBool("Muerte", false);
        anim.SetBool("Cacha", false);
        nav1.SetDestination(objetivo.transform.position);
    }
    void attackDistance()
    {
        //Debug.Log("atacar");
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", false);
        anim.SetBool("Ataque", true);
        anim.SetBool("Daño", false);
        anim.SetBool("Muerte", false);
        anim.SetBool("Cacha", false);
        nav1.SetDestination(transform.position);
        LanzarDardo();
    }
    void attackMele()
    {
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", false);
        anim.SetBool("Ataque", false);
        anim.SetBool("Daño", false);
        anim.SetBool("Muerte", false);
        anim.SetBool("Cacha", true);
        nav1.SetDestination(transform.position);
    }
    void morido()
    {
        anim.SetBool("Quieto", false);
        anim.SetBool("Camina", false);
        anim.SetBool("Ataque", false);
        anim.SetBool("Daño", false);
        anim.SetBool("Muerte", true);
        anim.SetBool("Cacha", false);
        vida = 0;
        vivo = false;
        zona.GetComponent<zona_enemigos_caza>().n_enemigos += 1;
        Destroy(gameObject, 4);
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
        b = Instantiate(ParticulaDaño, gameObject.transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        Destroy(b, 2);
        //poner animacion de daño al enemigo
        anim.SetBool("Ddaño", true);
        vida -= nim;
    }
    public void desactivar()
    {
        anim.SetBool("Ddaño", false);
        habilitado = true;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if ((other.GetComponent<Combate>().dam1 || other.GetComponent<Combate>().dam2 || other.GetComponent<Combate>().dam3) && habilitado)
            {
                RecibeDaño(200);
                habilitado = false;
            }
        }
    }
    public void LanzarDardo()
    {
        PosicionAMirar = Observando.transform.position;
        Observador.transform.LookAt(PosicionAMirar + new Vector3(XPos, YPos, Zpos));
        time -= Time.deltaTime;
        if (time<=0)
        {
            Instantiate(Dardo, DardoSpawn.transform.position, Rifle.transform.rotation);
            time = 1.5f;
        }
    }
}
