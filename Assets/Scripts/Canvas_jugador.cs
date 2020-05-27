using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvas_jugador : MonoBehaviour
{
    public float vida,puntos;
    float timer,vida_aux;
    bool bb=false,regen;
    public Image barra;
    public TextMeshProUGUI var_name,points;
    public GameObject a1, a2, a3, a4,a5,barra_vida,showarm;
    public GameObject show1,show2,show3,show4,show5,C_mision,Hub_mision,peligro;
    public TextMeshProUGUI C_text, C_text2;
    //public Canvas CaMuerte;
    public RawImage RI;
    public GameObject CosasMuerte;
    //variables pausa juego
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public int M_Active,tip_mision,prog_mision;


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
        barra.fillAmount = vida / 100;
        if (vida <= 0)
        {
            RI.color += new Color(0, 0, 0, 0.1f * Time.deltaTime);
            if (RI.color.a >= 1)
            {
                Muerte();
            }
        }

        //verificar si se pausa el juego
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (vida<100)
        {
            if (timer==0)
            {
                vida_aux = vida;
            }
            timer += Time.deltaTime;
            if (timer>=15&&!regen)
            {
                if (vida_aux==vida)
                {
                    regen = true;
                }
                else
                {
                    vida_aux = vida;
                    timer=0;
                }
            }
            if (regen)
            {
                vida += 5 * Time.deltaTime;
            }
        }

    }
    public void puntaje(int n)
    {
        puntos += n;
        points.text = puntos+"";
    }
    public void daño(float damage)
    {
        vida -= damage;
        regen = false;
        timer = 0;
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
                a5.SetActive(false);

                show1.SetActive(false);
                show2.SetActive(true);
                show3.SetActive(false);
                show4.SetActive(false);
                show5.SetActive(false);
                break;
            case 3:
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(true);
                a4.SetActive(false);
                a5.SetActive(false);

                show1.SetActive(false);
                show2.SetActive(false);
                show3.SetActive(true);
                show4.SetActive(false);
                show5.SetActive(false);
                break;
            case 4:
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(true);
                a5.SetActive(false);

                show1.SetActive(false);
                show2.SetActive(false);
                show3.SetActive(false);
                show4.SetActive(true);
                show5.SetActive(false);
                break;
            case 5:
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(false);
                a5.SetActive(true);

                show1.SetActive(false);
                show2.SetActive(false);
                show3.SetActive(false);
                show4.SetActive(false);
                show5.SetActive(true);
                break;
            default:
                a1.SetActive(true);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(false);
                a5.SetActive(false);

                show1.SetActive(true);
                show2.SetActive(false);
                show3.SetActive(false);
                show4.SetActive(false);
                show5.SetActive(false);
                break;
        }
    }
    
    void Muerte()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = true;
        CosasMuerte.SetActive(true);
        Cursor.visible = true;
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

    //creo mis metodos pausa
    public void Resume()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        
    }

    public void regenerar_vida()
    {

    }
    void Pause()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Destroy(GameObject.Find("Datos_player"));
        Destroy(GameObject.Find("jugador"));
        Destroy(GameObject.Find("Canvas_base"));
        Debug.Log("Has Cargado el menu principal");
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Salir()
    {
        Debug.Log("Has salido");
        Application.Quit();
    }


    public void rechazar_mision()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        C_text.text = " ";
        C_mision.SetActive(false);
        barra_vida.SetActive(true);
        showarm.SetActive(true);
    }
    public void aceptar_mision()
    {
        rechazar_mision();
        Hub_mision.SetActive(false);
        Hub_mision.SetActive(true);
        if (tip_mision == 1)
        {
            C_text2.text = "Investiga el Bosque";
            M_Active = 1;
        }
        else if (tip_mision == 2)
        {
            C_text2.text = "Investiga las montañas";
            M_Active = 2;
        }
        else if (tip_mision == 3)
        {
            C_text2.text = "Investiga el lago";
            M_Active = 3;
        }
        else if (tip_mision == 4)
        {
            C_text2.text = "Destruye los puestos de tala "+ prog_mision+"/5";
        }
        else if (tip_mision == 5)
        {
            C_text2.text = "Libera los grupos de animales " + prog_mision + "/4";
        }
        else if (tip_mision == 6)
        {
            C_text2.text = "destruye las petroleras " + prog_mision + "/6";
        }
        else if(tip_mision==10)
        {
            Hub_mision.SetActive(false);
        }
    }
    public void zona_peligro()
    {
        Hub_mision.SetActive(false);
        Hub_mision.SetActive(true);
        peligro.SetActive(!peligro.activeInHierarchy);
        if (!peligro.activeInHierarchy)
        {
            aceptar_mision();
        }
    }
    public void zona_progreso(int ene,int p)
    {
        C_text2.text = "enemigos derrotados " + ene + "/" + p;
    }
    public void terminar_zona()
    {
        if (tip_mision == 4)
        {
            C_text2.text = "Elimina los puestos";
        }
        else if (tip_mision == 5)
        {
            C_text2.text = "Libera Jaula(s)";
        }
        else if (tip_mision == 6)
        {
            C_text2.text = "Elimina las petroleras";
        }
    }
    public void varios(int ene)
    {
        switch (ene)
        {
            case 1:
                C_text2.text = "Derrota a Jaxon";
                break;
            case 2:
                C_text2.text = "Derrota a Dominic";
                break;
            case 3:
                C_text2.text = "Derrota a Mason";
                break;
            case 4:
                C_text2.text = "Vuelve al pueblo";
                break;
            default:
                break;
        }
    }
}
