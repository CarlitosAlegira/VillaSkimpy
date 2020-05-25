using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject part;
    bool dest;
    GameObject player;
    [SerializeField] Transform spawn;
    public GameObject minimapa;
    
    private void Awake()
    {
        dest=false;
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().act_desc_Hud();
        player.GetComponent<Inventario>().trans = true;
        GameObject.Find("Main").GetComponent<Camera>().enabled = true;
        minimapa.SetActive(true);
    }
    private void Start()
    {
        GameObject clon= Instantiate(part,transform.position,part.transform.rotation) as GameObject;
        Destroy(clon, 5);
        if (dest)
        {
            Destroy(clon);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            dest = true;
        }
    }
}
