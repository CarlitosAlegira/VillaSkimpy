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
    bool idle ;
    public bool keyframe1, atacking, menu;
    
    void Start()
    {
        
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
            anim.SetBool("caminar", false);
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
        if (!atacking && !menu)
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move = move * velocidad*2;
            anim.SetBool("caminar", false);
            anim.SetBool("Correr", true);
        }
        else
        {
            anim.SetBool("Correr", false);
            move = move * velocidad;
        }
        gravedad();

        jugador.Move(move *Time.deltaTime);
    }

    void gravedad()
    {
            move.y = -grav;
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
