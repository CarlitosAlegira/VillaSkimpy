using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Datos : MonoBehaviour
{
    public TextMeshProUGUI hero_name;
    string nombre;
    public int hero;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        nombre = "daniel";
        hero = 2;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nombre_jugador()
    {
        nombre = hero_name.text;
    }
    public void Character(int num)
    {
        hero = num;
    }
}
