using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjustesdeBase : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource LoQueSuena;
    public float fBrillo, fVolumen;
    MOpciones Mo;
    GameObject Go;
  
   
    
    void Start()
    {
        Go = GameObject.Find("ContenedorOpciones");
        LoQueSuena = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fBrillo = Go.GetComponent<MOpciones>().Brillo;
        fVolumen = Go.GetComponent<MOpciones>().Volumen;
        RenderSettings.ambientIntensity = fBrillo;
        LoQueSuena.volume = fVolumen;
    }
}
