using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Datos : MonoBehaviour
{
    private string log = "http://villaskimpy.000webhostapp.com/actualizar.php";
    string user, pass;
    public Text hero_name;
    string nombre;
    public string nombre_save;
    int a1, a2, a3,a4;
    public int hero,mision,progreso, zona;
    bool repetido;
    public int[]bosque,caza,petroleo;
    public float t1, t2, t3;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        bosque = new int[5];
        caza = new int[4];
        petroleo = new int[6];
    }
    public void nombre_jugador()
    {
        nombre = hero_name.text.Trim();
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
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().armas[4])
        {
            a4 = 1;
        }
        string Sdatos = nombre + "," + GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().vida + "," +
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().Active + "," + a1 + "," + a2 + "," + a3 + "," + a4 + "," +
                hero + "," + mision + "," + progreso+","+bosque[0] + "," + bosque[1] + "," + bosque[2] + "," + bosque[3] + "," + bosque[4]
                 + "," + caza[0] + "," + caza[1] + "," + caza[2] + "," + caza[3]
                  + "," + petroleo[0] + "," + petroleo[1] + "," + petroleo[2] + "," + petroleo[3] + "," + petroleo[4] + "," + petroleo[5] 
                  +","+GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().puntos;
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
            actualizar();
        }
        else
        {
            Debug.Log("paso");
            GameObject.Find("data").GetComponent<guardar>().error();
        }

    }
    public void actualizar()
    {
        StartCoroutine("actua_corr");
    }

    public IEnumerator actua_corr()
    {
        user = GameObject.Find("Usuario").GetComponent<G_user>().name;
        pass = GameObject.Find("Usuario").GetComponent<G_user>().pass;
        string urlusing = log + "?user=" + user + "&t1=" + (int)t1/60 + "&t2=" + (int)t2/60 + "&t3=" + (int)t3/60 + "&score=" + GameObject.Find("Canvas_base").GetComponent<Canvas_jugador>().puntos;
        WWW validate = new WWW(urlusing);
        Debug.Log(urlusing);
        yield return validate;
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
        GameObject.Find("data").GetComponent<guardar>().boton_volver();
    }
}
