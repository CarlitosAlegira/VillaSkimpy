using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_spawns : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Transform bosque, caza, lago, basico;
    int Zona;
    private void Awake()
    {
        Zona = GameObject.Find("Datos_player").GetComponent<Datos>().zona;
        player = GameObject.FindGameObjectWithTag("Player");
        switch (Zona)
        {
            case 1:
                player.transform.position = bosque.position;
                player.transform.rotation = bosque.rotation;
                GameObject.Find("Datos_player").GetComponent<Datos>().zona = 0;
                break;
            case 2:
                player.transform.position = caza.position;
                player.transform.rotation = caza.rotation;
                GameObject.Find("Datos_player").GetComponent<Datos>().zona = 0;
                break;
            case 3:
                player.transform.position = lago.position;
                player.transform.rotation = lago.rotation;
                break;
            default:
                player.transform.position = basico.position;
                player.transform.rotation = basico.rotation;
                break;
        }
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().act_desc_Hud();
        player.GetComponent<Inventario>().trans = true;
    }
}
