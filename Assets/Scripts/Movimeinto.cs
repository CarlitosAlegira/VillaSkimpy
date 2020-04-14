using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimeinto : MonoBehaviour
{
    public float velocidad;
    private float pox, poy,pog,grav,timer,rand;
    public CharacterController jugador;
    public Camera camaraP;
    string nombre_player;
    int cha_player;
    Vector3 move,datos_in,camFrente,camDerecha;
    Animator anim;
    bool idle,pararse,agac_vel,onslide;
    public bool keyframe1, agachado, atacking,atack_run, menu;
    
    void Start()
    {
        pararse = true;
        grav = 9.8f;
        jugador = GetComponent<CharacterController>();
        anim = jugador.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (pox == 0 && poy == 0)
        {
            anim.SetBool("quieto", true);
            timer += 1 * Time.deltaTime;
            if (timer >= 5  && !atacking)
            {
                if (idle)
                {
                    rand = Random.Range(-1.1f, 4.5f);
                    anim.SetFloat("idle", rand);
                    idle = false;
                }
                if (timer >= 9)
                {
                    rand = 0;
                    anim.SetFloat("idle", rand);
                    timer = 0;
                    idle = true;
                }
            }
        }
        else
        {
            anim.SetBool("quieto", false);
            timer = 0;
            idle = true;
            anim.SetFloat("Pox", pox);
            anim.SetFloat("Poy", poy);
            anim.SetBool("caminar", true);
            anim.SetBool("Combat", false);
        }
        if (!atacking && !menu || atack_run)
        {
            pox = Input.GetAxis("Horizontal");
            poy = Input.GetAxis("Vertical");
        }
        else
        {
            pox = 0;
            poy = 0;
        }
        
        datos_in = new Vector3(pox, 0, poy);
        datos_in = Vector3.ClampMagnitude(datos_in, 1);
        camara();
        move = datos_in.x* camDerecha + datos_in.z*camFrente;
        jugador.transform.LookAt(jugador.transform.position+move);
        if (Input.GetKey(KeyCode.LeftShift) && !atacking && (pox != 0 || poy != 0) && pararse)
        {
            move = move * velocidad*2;
            anim.SetBool("Correr", true);
            jugador.GetComponent<Combate>().Running = true;
            if (Input.GetKeyDown(KeyCode.C))
            {
                onslide = true;
                anim.SetBool("Agacharse", true);
            }
        }
        else
        {
            jugador.GetComponent<Combate>().Running = false;
            if (onslide)
            {
                anim.SetBool("Correr", false);
                move = move * velocidad*1.5f;
            }
            else if (agachado)
            {
                anim.SetBool("Correr", false);
                move = move * velocidad * 0.5f;
            }
            else
            {
                anim.SetBool("Correr", false);
                move = move * velocidad;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            slide();
        }
        gravedad();

        jugador.Move(move *Time.deltaTime);
    }

    void gravedad()
    {
        move.y = -grav;
    }
    
    public void slide()
    {
        if (agachado)
        {
            jugador.GetComponent<CharacterController>().center = (new Vector3(0, 0.92f, 0));
            jugador.GetComponent<CharacterController>().height = 1.67f;
            if (pox != 0 || poy != 0)
            {
                anim.SetBool("Agacharse", false);
                anim.SetBool("caminar", true);
            }
            else
            {
                anim.SetBool("Agacharse", false);
                anim.SetBool("caminar", false);
            }
            agac_vel = false;
            onslide = false;
            pararse = true;
            agachado = false;
        }
        else if (pararse)
        {
            jugador.GetComponent<CharacterController>().center=(new Vector3(0,0.61f,0));
            jugador.GetComponent<CharacterController>().height=1;
            if (pox != 0 || poy != 0)
            {
                anim.SetBool("Agacharse", true);
                anim.SetBool("caminar", true);
            }
            else
            {
                anim.SetBool("Agacharse", true);
                anim.SetBool("caminar", false);
            }
            agachado = true;
            pararse = false;
        }
    }
    void parar_slide()
    {
        onslide = false;
    }

    void camara()
    {
        camFrente = camaraP.transform.forward;
        camDerecha = camaraP.transform.right;
        camFrente.y = 0;
        camDerecha.y = 0;
        camFrente = camFrente.normalized;
        camDerecha = camDerecha.normalized;
    }
}
