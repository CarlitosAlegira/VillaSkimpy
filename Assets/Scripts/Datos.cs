using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Datos : MonoBehaviour
{
    public TextMeshProUGUI hero_name;
    string nombre;
    public int hero,zona;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }
    public void nombre_jugador()
    {
        nombre = hero_name.text;
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().nombre(nombre);
    }
    public void Character(int num)
    {
        hero = num;
    }
}
