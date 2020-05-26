using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Dominic: MonoBehaviour
{
    // Start is called before the first frame update
    enum Stados
    {
        IDLE, FOLLOW, ATTACKDISTANCE, ATTACKMELE ,EMBESTIDA
    }
    public float vida, VidaMax, delay, fireRate, XPos, YPos, Zpos, timeLeft = 5;
    public float vidaE1=1500, vidaE2=1000, vidaE3=500;
    float time = 1.5f, timesito;
    //public float TamañoBarra;
    Stados currentstate;
    public Animator anim;
    NavMeshAgent nav1;
    public GameObject objetivo, ParticulaDaño, BarraVida, Dardo, DardoSpawn, Observador, Observando, Rifle, b, encerrar, correr;
    public ParticleSystem Particula;
    public float disActual, disReferencia, disReferencia2, disReferencia3, timer; 
    private Vector3 PosicionAMirar;
    bool habilitado = true, vivo = true, call, vp = true, vp2 = true, vp3 = true, pvez=true;
    public GameObject zona;
    void Start()
    {
        delay = 1;
        fireRate = 1.5f;
        VidaMax = 2000f;
        vida = 2000f;
        objetivo = GameObject.FindGameObjectWithTag("Player");
        Observando = GameObject.FindGameObjectWithTag("Player");
        nav1 = GetComponent<NavMeshAgent>();
        disReferencia = 10f;
        disReferencia2 = 5f;
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
                 //call = true;
                }
            
        }
    }

    void checkConditions()
    {
        if (vivo)
        {
            disActual = Vector3.Distance(objetivo.transform.position, transform.position);
            if (vida <= vidaE1 && vp)
            {
                currentstate = Stados.EMBESTIDA;
                timeLeft -= 1*Time.deltaTime;
                if (timeLeft <=0)
                {
                    timeLeft = 5;
                    vp= false;
                }
            }
            else
            {
                if (vida <= vidaE2 && vp2)
                {
                    currentstate = Stados.EMBESTIDA;
                    timeLeft -= 1 * Time.deltaTime;
                    if (timeLeft <= 0)
                    {
                        timeLeft = 5;
                        vp2 = false;
                    }
                }
                else
                {
                    if (vida <= vidaE3 && vp3)
                    {
                        currentstate = Stados.EMBESTIDA;
                        timeLeft -= 1 * Time.deltaTime;
                        if (timeLeft <= 0)
                        {
                            timeLeft = 5;
                            vp3 = false;
                        }
                    }else
                    {
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
            case Stados.EMBESTIDA:
                Embestir();
                break;
            default:
                break;
        }
    }
    void idle()
    {
        DarDaño(2);
        anim.SetBool("quieto", true);
        anim.SetBool("camina", false);
        anim.SetBool("tiro", false);
        anim.SetBool("cacha", false);
        anim.SetBool("embestida", false);
        anim.SetBool("daño", false);
        anim.SetBool("muerte", false);
        nav1.SetDestination(transform.position);
    }
    void follow()
    {
        DarDaño(2);
        anim.SetBool("quieto", false);
        anim.SetBool("camina", true);
        anim.SetBool("tiro", false);
        anim.SetBool("cacha", false);
        anim.SetBool("embestida", false);
        anim.SetBool("daño", false);
        anim.SetBool("muerte", false);
        nav1.SetDestination(objetivo.transform.position);
    }
    void attackDistance()
    {
        //Debug.Log("atacar");
        anim.SetBool("quieto", false);
        anim.SetBool("camina", false);
        anim.SetBool("tiro", true);
        anim.SetBool("cacha", false);
        anim.SetBool("embestida", false);
        anim.SetBool("daño", false);
        anim.SetBool("muerte", false);
        nav1.SetDestination(transform.position);
        LanzarDardo();
    }
    void attackMele()
    {
        anim.SetBool("quieto", false);
        anim.SetBool("camina", false);
        anim.SetBool("tiro", false);
        anim.SetBool("cacha", true);
        anim.SetBool("embestida", false);
        anim.SetBool("daño", false);
        anim.SetBool("muerte", false);
        nav1.SetDestination(transform.position);
    }
    void Embestir()
    {
        anim.SetBool("quieto", false);
        anim.SetBool("camina", false);
        anim.SetBool("tiro", false);
        anim.SetBool("cacha", false);
        anim.SetBool("embestida", true);
        anim.SetBool("daño", false);
        anim.SetBool("muerte", false);
        nav1.SetDestination(objetivo.transform.position);
    }
    void morido()
    {
        anim.SetBool("quieto", false);
        anim.SetBool("camina", false);
        anim.SetBool("tiro", false);
        anim.SetBool("cacha", false);
        anim.SetBool("embestida", false);
        anim.SetBool("daño", false);
        anim.SetBool("muerte", true);
        vida = 0;
        vivo = false;
        if (pvez)
        {
            Debug.Log("entra al ganar");
            timesito += 1 * Time.deltaTime;
            if (timesito >= 8)
            {
                ganar();
            }
            
        }
        //zona.GetComponent<zona_enemigos_caza>().n_enemigos += 1;
        //Destroy(gameObject, 4);
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
        anim.SetBool("daño", true);
        vida -= nim;
    }
    public void desactivar()
    {
        anim.SetBool("daño", false);
        habilitado = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           if(anim.GetBool("embestida")==true)
           {
                if (vp==false)
                {
                    if (vp2 ==false)
                    {
                        objetivo.GetComponent<Combate>().rec_golpe = true;
                        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().daño(25.9f);
                        anim.SetBool("quieto", true);
                        anim.SetBool("camina", false);
                        anim.SetBool("tiro", false);
                        anim.SetBool("cacha", false);
                        anim.SetBool("embestida", false);
                        anim.SetBool("daño", false);
                        anim.SetBool("muerte", false);
                        vp3 = false;
                    }
                    else
                    {
                        objetivo.GetComponent<Combate>().rec_golpe = true;
                        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().daño(25.9f);
                        anim.SetBool("quieto", true);
                        anim.SetBool("camina", false);
                        anim.SetBool("tiro", false);
                        anim.SetBool("cacha", false);
                        anim.SetBool("embestida", false);
                        anim.SetBool("daño", false);
                        anim.SetBool("muerte", false);
                        vp2 = false;
                    }
                }
                else
                {
                    objetivo.GetComponent<Combate>().rec_golpe = true;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().daño(25.9f);
                    anim.SetBool("quieto", true);
                    anim.SetBool("camina", false);
                    anim.SetBool("tiro", false);
                    anim.SetBool("cacha", false);
                    anim.SetBool("embestida", false);
                    anim.SetBool("daño", false);
                    anim.SetBool("muerte", false);
                    vp = false;
                }
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if ((other.GetComponent<Combate>().dam1 || other.GetComponent<Combate>().dam2 || other.GetComponent<Combate>().dam3) && habilitado)
            {
                RecibeDaño(200*Time.deltaTime);
                //habilitado = false;
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

    public void ganar()
    {
        encerrar.SetActive(false);
        //gameObject.transform.LookAt(new Vector3(correr.transform.position.x, transform.position.y, correr.transform.position.z));
        //transform.Translate(0, 0, 5 * Time.deltaTime);
        nav1.SetDestination(correr.transform.position);
        anim.SetBool("quieto", false);
        anim.SetBool("camina", false);
        anim.SetBool("tiro", false);
        anim.SetBool("cacha", false);
        anim.SetBool("embestida", true);
        anim.SetBool("daño", false);
        anim.SetBool("muerte", false);
        timer += Time.deltaTime;
        Debug.Log("timer: "+timer);
        if (timer >= 15)
        {
            Destroy(gameObject);
            Debug.Log("dentro del gg");
            zona.GetComponent<ZonaFinal_2>().can_win.SetActive(true);
            objetivo.GetComponent<Inventario>().menus2 = true;
            objetivo.GetComponent<Movimeinto>().menu = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pvez = false;
        }
    }
    public void cerrar()
    {
        encerrar.SetActive(!encerrar.activeInHierarchy);
        zona.GetComponent<ZonaFinal_2>().canDialogo.SetActive(false);
        objetivo.GetComponent<Inventario>().menus2 = false;
        objetivo.GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //comenzar();
    }
}
