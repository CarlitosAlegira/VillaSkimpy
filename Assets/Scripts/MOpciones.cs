using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MOpciones : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Sl1, Sl2;
    AudioSource As;
    public float Brillo, Volumen;
   
    void Start()
    {
        As = GetComponent<AudioSource>();
        Brillo = 0.5f;
        Volumen = 0.5f;
    }

    // Update is called once per frame
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
