using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_spawns : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Transform bosque, caza, petroleo, basico;
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
                break;
            case 2:
                player.transform.position = caza.position;
                player.transform.rotation = caza.rotation;
                break;
                /*
            case 3:
                player.transform.position = llanura.position;
                player.transform.rotation = llanura.rotation;
                break;
            case 4:
                player.transform.position = petroleo.position;
                player.transform.rotation = petroleo.rotation;
                break;*/
            default:
                player.transform.position = basico.position;
                player.transform.rotation = basico.rotation;
                break;
        }
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().act_desc_Hud();
        player.GetComponent<Inventario>().trans = true;
    }
}
