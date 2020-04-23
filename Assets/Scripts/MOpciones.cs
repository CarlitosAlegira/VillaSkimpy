using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MOpciones : MonoBehaviour
{

    public Slider Sl1, Sl2;
    AudioSource As;
    public float Brillo, Volumen;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        As = GetComponent<AudioSource>();
        Brillo = 0.5f;
        Volumen = 0.5f;
    }
    private void Update()
    { 

    }


    public void AjustaBrillo()
    {
        Brillo = Sl1.value;
        RenderSettings.ambientIntensity = Brillo;
    }
    public void AjustarVolumen()
    {
        Volumen = Sl2.value;
        As.volume = Volumen;
        
    }
   
}
