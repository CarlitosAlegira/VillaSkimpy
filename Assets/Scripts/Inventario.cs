using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject arma1, arma2, arma3, arma4,inv,mos_arma;
    public bool[] armas;
    public bool menus2;
    private void Start()
    {
        armas = new bool[5];
        armas[0] = true;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && !menus2)
        {
            mostrar_inv();
            Cursor.lockState = CursorLockMode.None;

        }
        else if (!menus2)
        {
            Cursor.lockState = CursorLockMode.Locked;
            inv.SetActive(false);
            mos_arma.SetActive(true);
            gameObject.GetComponent<Movimeinto>().menu = false;
        }
        if (menus2)
        {
            gameObject.GetComponent<Movimeinto>().menu = true;
        }
    }

    void mostrar_inv()
    {
        inv.SetActive(true);
        mos_arma.SetActive(false);
        arma1.SetActive(true);
        gameObject.GetComponent<Movimeinto>().menu = true;
        if (armas[1])
        {
            arma2.SetActive(true);
        }
        if (armas[2])
        {
            arma3.SetActive(true);
        }
        if (armas[3])
        {
            arma4.SetActive(true);
        }
    }
    public void select_arm(int num)
    {
        switch (num)
        {
            case 1:
                if (armas[0])
                {
                    gameObject.GetComponent<Combate>().Weapon = 1;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().weapon(1);
                }
                break;
            case 2:
                if (armas[1])
                {
                    gameObject.GetComponent<Combate>().Weapon = 2;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().weapon(2);
                }
                break;
            case 3:
                if (armas[2])
                {
                    gameObject.GetComponent<Combate>().Weapon = 3;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().weapon(3);
                }
                break;
            case 4:
                if (armas[3])
                {
                    gameObject.GetComponent<Combate>().Weapon = 4;
                    GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().weapon(4);
                }
                break;
            default:
                break;
        }
    }
}
