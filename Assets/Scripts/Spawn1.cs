using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    GameObject player;
    [SerializeField] Transform spawn;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;

    }
}
