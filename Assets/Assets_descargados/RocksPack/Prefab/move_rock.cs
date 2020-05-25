using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_rock : MonoBehaviour
{
    public float vel=5;
    void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,vel*Time.deltaTime);
    }
}
