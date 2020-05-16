using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuidaAnimal : MonoBehaviour
{
    // Start is called before the first frame update
    public float tiempo, velocidad;
    public bool collision, Huir=false, Encerrado = true;
    bool girando, p, p2=true;
    Animator anim;
    public float tiempo2 = 0, tiempo3 = 0;
    float y;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //velocidad = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Huir && !p)
        {
            if (tiempo3 >=3)
            {
                if (tiempo2 >= 10)
                {
                    p = true;
                    p2 = false;
                    anim.SetBool("caminar", false);
                    transform.Translate(new Vector3(0, 0, 0) * velocidad * Time.deltaTime);
                }
                else
                {
                    transform.Translate(new Vector3(0, 0, 1) * velocidad * Time.deltaTime);
                    anim.SetBool("caminar", true);
                }
                tiempo2 += 1 * Time.deltaTime;
            }
            tiempo3 += 1 * Time.deltaTime;
        }
        else 
        {
            if (Encerrado)
            {

            }
            else
            {
                if (!collision)
                {
                    tiempo += 1 * Time.deltaTime;
                    if (tiempo >= 2)
                    {
                        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
                        transform.transform.Rotate(new Vector3(0, y, 0));
                        anim.SetBool("caminar", true);
                    }
                    else
                    {
                        anim.SetBool("caminar", false);
                    }
                    if (tiempo >= Random.Range(10, 30))
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
        }
    }
    void girar()
    {
        y = Random.Range(-3, 3);
    }
    private void OnTriggerExit(Collider other)
    {
        collision = false;
        y = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        collision = true;
        girar();
    }
}
