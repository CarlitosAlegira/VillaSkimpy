using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Datos : MonoBehaviour
{
    public TextMeshProUGUI hero_name;
    string nombre;
    public string nombre_save;
    int a1, a2, a3;
    public int hero, zona;
    bool repetido;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void nombre_jugador()
    {
        nombre = hero_name.text+"1";
        GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().nombre(nombre);
    }
    public void carga(string name,int her)
    {
        nombre = name;
        hero = her;
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
            string añadir = PlayerPrefs.GetString("Partidas","none");
            string[] val = añadir.Split(",".ToCharArray());
            repetido = false;
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == nombre_save)
                {
                    repetido = true;
                }
            }
            if (!repetido)
            {
                guardar_partida(añadir);
            }
            else
            {
                GameObject.Find("data").GetComponent<guardar>().error();
            }

            guardar_datos(Sdatos);
        }
        else
        {
            GameObject.Find("data").GetComponent<guardar>().error();
        }
    }
    void  guardar_partida(string anadir)
    {
        string N_data = anadir + nombre_save + ",";
        Debug.Log(N_data);
        PlayerPrefs.SetString("Partidas", N_data);
        PlayerPrefs.Save();
    }
    void guardar_datos(string Sdatos)
    {
        PlayerPrefs.SetString(nombre_save, Sdatos);
        Debug.Log(Sdatos);
        PlayerPrefs.Save();
    }
}
