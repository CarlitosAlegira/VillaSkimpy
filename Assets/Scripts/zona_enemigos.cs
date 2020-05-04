using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona_enemigos : MonoBehaviour
{
    public GameObject p_tala1, p_tala2, p_tala3, tienda;
    public int n_enemigos,dest,enemigos_base;
    bool p,p2,entro;
    void Start()
    {
        
    }
    void Update()
    {
        if (entro)
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_progreso(n_enemigos, enemigos_base);
        }
        if (n_enemigos >= enemigos_base && !p2)
        {
            p_tala1.GetComponent<destruir>().dest = true;
            p_tala2.GetComponent<destruir>().dest = true;
            p_tala3.GetComponent<destruir>().dest = true;
            tienda.GetComponent<destruir>().dest = true;
            p2 = true;
        }
        if (!p && dest >= 4)
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().prog_mision += 1;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().aceptar_mision();
            p = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            entro = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
            entro = false;
        }
    }
}
