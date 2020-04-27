using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    bool coll;
    private void Update()
    {
        if (coll)
        {
            Destroy(gameObject,8);
        }
        else
        {
            transform.Translate(1, 0, 0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        transform.position += other.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        coll = true;
        transform.Translate(0, 0, 0);
    }
}
