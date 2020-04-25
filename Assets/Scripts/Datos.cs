using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Datos : MonoBehaviour
{
    public TextMeshProUGUI hero_name;
    string nombre;
    public string nombre_save="prueba";
    int a1, a2, a3;
    public int hero, zona;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
    public void Guardar()
    {

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().armas[1])
        {
            a1 = 1;
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().armas[2])
        {
            a2 = 1;
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().armas[3])
        {
            a3 = 1;
        }
        string Sdatos = nombre + "," + GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().vida + "," +
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().Active + "," + a1 + "," + a2 + "," + a3 + "," +
                hero + "," + zona;
        string prueba = PlayerPrefs.GetString(nombre_save,"none");
        if (prueba=="none")
        {
            PlayerPrefs.SetString(nombre_save, Sdatos);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("repetido");
        }
    }
}
