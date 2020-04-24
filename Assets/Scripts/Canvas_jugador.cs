using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Canvas_jugador : MonoBehaviour
{
    public float vida;
    bool bb=false;
    public Image barra;
    public TextMeshProUGUI var_name;
    public GameObject a1, a2, a3, a4,barra_vida,showarm;
    //public Canvas CaMuerte;
    public RawImage RI;
    public GameObject CosasMuerte;
    private void Awake()
    {
            DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        weapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = vida/100;
        if (vida<=0)
        {
            RI.color += new Color(0,0,0,0.1f*Time.deltaTime);
            if (RI.color.a >= 1)
            {
                Muerte();
            }
        }
            
            
    }
    public void daño(float damage)
    {
        vida -= damage;
    }
    public void weapon(int arma)
    {
        switch (arma)
        {
            case 2:
                a1.SetActive(false);
                a2.SetActive(true);
                a3.SetActive(false);
                a4.SetActive(false);
                break;
            case 3:
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(true);
                a4.SetActive(false);
                break;
            case 4:
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(true);
                break;
            default:
                a1.SetActive(true);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(false);
                break;
        }
    }
    
    void Muerte()
    {
        CosasMuerte.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void nombre(string name)
    {
        var_name.text = name;
    }
    
    public void act_desc_Hud()
    {
        barra_vida.SetActive(!barra_vida.activeInHierarchy);
        showarm.SetActive(!showarm.activeInHierarchy);
    }
}
