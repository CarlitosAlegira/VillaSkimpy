using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona_enemigos : MonoBehaviour
{
    public GameObject p_tala1, p_tala2, p_tala3, tienda,par1,par2,par3,par4;
    GameObject b1, b2, b3, b4;
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
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().terminar_zona();
            p2 = true;
            entro = false;
        }
        if (!p && dest >= 4)
        {
            p = true;
            parti();
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().prog_mision += 1;
            GameObject.Find("Datos_player").GetComponent<Datos>().progreso += 1;
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().aceptar_mision();
            gameObject.SetActive(false);
            GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().zona_peligro();
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
    void parti()
    {
        b1 = Instantiate(par1, transform.position, par1.transform.rotation);
        Destroy(b1, 4);
        b2 = Instantiate(par2, transform.position, par2.transform.rotation);
        Destroy(b2, 4);
        b3 = Instantiate(par3, transform.position, par3.transform.rotation);
        Destroy(b3, 4);
        b4 = Instantiate(par4, transform.position, par4.transform.rotation);
        Destroy(b4, 8);
    }
}
