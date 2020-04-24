using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject part;
    bool dest;
    GameObject player;
    [SerializeField] Transform spawn;
    
    private void Awake()
    {
        dest=false;
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
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
