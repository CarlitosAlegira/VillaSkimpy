using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_jugador : MonoBehaviour
{
    public float vida;
    public Image barra;
    public GameObject a1, a2, a3, a4;
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
            float alphaactual = RI.color.a;
            RI.color = new Color(RI.color.r, RI.color.g, RI.color.b, RI.color.a + 0.02f);
            if (alphaactual >= 1)
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
}
