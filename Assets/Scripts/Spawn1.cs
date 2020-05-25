using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject part,tuto;
    bool dest,saltar;
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
    public void continuar()
    {
        tuto.SetActive(false);
        player.GetComponent<Inventario>().menus2 = false;
        player.GetComponent<Movimeinto>().menu = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        saltar = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            dest = true;
            if (GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().prog_mision == 0 && !saltar)
            {
                tuto.SetActive(true);
                other.GetComponent<Inventario>().menus2 = true;
                other.GetComponent<Movimeinto>().menu = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
