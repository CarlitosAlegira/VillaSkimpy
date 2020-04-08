﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class Selectcharacter : MonoBehaviour
{
    // Start is called before the first frame update
    Animator a1, a2, a3;
    public GameObject c1, c2, c3, panel, ambiente,panel_name,error;
    public Image img;
    int aa,ab;
    bool step1;
    float timer;
    void Start()
    {
        a1 = c1.GetComponent<Animator>();
        a2 = c2.GetComponent<Animator>();
        a3 = c3.GetComponent<Animator>();
        img = img.GetComponent<Image>();
        img.color = new Color(0.2621485F, 0.4056604F, 0.4017817F, 1F);
        error.SetActive(false);

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
    public void Selectedcharacter(int num)
    {
        aa = Random.Range(1, 10);
        ab = Random.Range(1, 10);
        
        switch (num)
        {
            case 1:
                a1.SetBool("selected",true);
                a2.SetInteger("no_s", aa);
                a3.SetInteger("no_s", ab);
                break;
            case 2:
                a2.SetBool("selected", true);
                a1.SetInteger("no_s", aa);
                a3.SetInteger("no_s", ab);
                break;
            case 3:
                a3.SetBool("selected", true);
                a2.SetInteger("no_s", aa);
                a1.SetInteger("no_s", ab);
                break;
            default:
                break;
                
        }
        panel.SetActive(false);
        step1 = true;
    }
    public void guardar()
    {
        EditorSceneManager.LoadScene(1);
    }
}
