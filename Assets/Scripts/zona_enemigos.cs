using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zona_enemigos : MonoBehaviour
{
    public GameObject p_tala1, p_tala2, p_tala3, tienda;
    public int n_enemigos;
    bool p;
    void Start()
    {
        
    }
    void Update()
    {
        if (n_enemigos >= 8)
        {
            p_tala1.GetComponent<destruir>().dest = true;
            p_tala2.GetComponent<destruir>().dest = true;
            p_tala3.GetComponent<destruir>().dest = true;
            tienda.GetComponent<destruir>().dest = true;
            if (!p)
            {
                GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().prog_mision += 1;
                GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().aceptar_mision();
                p = true;
            }
        }
    }
}
