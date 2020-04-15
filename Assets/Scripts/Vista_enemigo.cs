using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista_enemigo : MonoBehaviour
{
    public GameObject enemigo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            enemigo.GetComponent<IA_enemigos>().enemi_see = true;
        }
    }
}
