using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapaScript : MonoBehaviour
{
    Transform player;
    GameObject Jugador;
    Camera camara;

    void Start()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player");
        player = Jugador.transform;

        camara = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);

        agrandarMinimapa();
    }


    void agrandarMinimapa()
    {
        if (Input.GetKey(KeyCode.M))
        {
            camara.rect = new Rect(0.1f, 0.1f, 0.8f, 0.8f);
            camara.orthographicSize = 100;
        }
        else
        {
            camara.rect = new Rect(0.8f, 0.75f, 0.15f, 0.2f);
            camara.orthographicSize = 30;
        }
    }

}
