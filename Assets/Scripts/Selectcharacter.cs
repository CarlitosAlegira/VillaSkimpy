using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selectcharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Select;
    AudioSource LoQueSuena;
    Animator a1, a2, a3;
    public GameObject c1, c2, c3, panel, ambiente,panel_name,error,b1,b2,b3,h1,h2,h3;
    public Image img;
    int aa,ab,per;
    bool step1;
    float timer;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        LoQueSuena = GetComponent<AudioSource>();
        a1 = c1.GetComponent<Animator>();
        a2 = c2.GetComponent<Animator>();
        a3 = c3.GetComponent<Animator>();
        img = img.GetComponent<Image>();
        img.color = new Color(0.2621485F, 0.4056604F, 0.4017817F, 1F);
        error.SetActive(false);
        LoQueSuena.clip = Select;
    }

    // Update is called once per frame
    void Update()
    {
        if (step1)
        {
            timer += Time.deltaTime;
            if (timer>=10)
            {
                ambiente.SetActive(false);
                panel_name.SetActive(true);
                step1= false;
            }
        }
    }
    void activar_per()
    {
        if (per==1)
        {
            h1.SetActive(true);
        }
        else if (per==2)
        {
            h2.SetActive(true);
        }
        else if (per==3)
        {
            h3.SetActive(true);
        }
    }
    public void Selectedcharacter(int num)
    {
        aa = Random.Range(1, 10);
        ab = Random.Range(1, 10);
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
        per = num;


        switch (num)
        {
            case 1:
                a1.SetBool("selected",true);
                a2.SetInteger("no_s", aa);
                a3.SetInteger("no_s", ab);
                Destroy(h2);
                Destroy(h3);
                LoQueSuena.Play();
                break;
            case 2:
                a2.SetBool("selected", true);
                a1.SetInteger("no_s", aa);
                a3.SetInteger("no_s", ab);
                Destroy(h1);
                Destroy(h3);
                LoQueSuena.Play();
                break;
            case 3:
                a3.SetBool("selected", true);
                a2.SetInteger("no_s", aa);
                a1.SetInteger("no_s", ab);
                Destroy(h2);
                Destroy(h1);
                LoQueSuena.Play();
                break;
            default:
                break;
                
        }
        panel.SetActive(false);
        step1 = true;
    }
    public void guardar()
    {
        activar_per();
        SceneManager.LoadScene(1);
    }
}
