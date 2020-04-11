using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Animals : MonoBehaviour
{
    public float tiempo, velocidad;
    public bool collision;
    bool girando;
    Animator anim;
    float y;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (!collision)
        {
            tiempo += 1 * Time.deltaTime;
            if (tiempo >= 1)
            {
                transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
                transform.transform.Rotate(new Vector3(0, y, 0));
                //anim.SetBool("caminar", true);
            }
            else
            {
                //anim.SetBool("caminar", false);
            }
            if (tiempo >= Random.Range(5, 30))
            {
                girar();
                girando = true;
                tiempo = 0;
            }
            if (girando)
            {
                if (tiempo >= Random.Range(1, 5))
                {
                    y = 0;
                    girando = false;
                    tiempo = 0;
                }
            }
        }
        else if (collision)
        {
            girar();
            transform.transform.Rotate(new Vector3(0, y, 0));
        }

    }
    public void girar()
    {
        y = Random.Range(-3, 3);
    }
    private void OnTriggerStay(Collider other)
    {
        collision = true;
        girar();
    }
    private void OnTriggerExit(Collider other)
    {
        collision = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.collision = true;
        girar();
    }
}
