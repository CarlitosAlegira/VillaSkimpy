using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustesVolyBrillo : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource Ass;
    float vol, brill;
    void Start()
    {
        Ass = GetComponent<AudioSource>();
        GameObject COP = GameObject.Find("ContenedorOpciones");
        vol = COP.GetComponent<MOpciones>().Volumen;
        brill = COP.GetComponent<MOpciones>().Brillo;
        Ass.volume = vol;
        RenderSettings.ambientIntensity = brill;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("volumen: " + vol);
        Debug.Log("brillo: " + brill);
    }
}
