using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLogin : MonoBehaviour
{
    public GameObject cargo;
    [Header("Registro")]

    public Text usuario_r;
    public Text nombre,apellido,correo,Ccorreo;
    public InputField password_r,Cpassword_r;
    public GameObject error2,error3;
    private string reg = "https://villaskimpy.000webhostapp.com/registerusergame.php";
    private string user_r, pass_r,correo_r,name_r,lastname_r;

    [Header("Login")]
    public Text usuario;
    public InputField password;
    public GameObject error1;
    private string log = "https://villaskimpy.000webhostapp.com/logusergame.php";
    private string user, pass;

    void Start()
    {   
    }

    void Update()
    {  
    }

    public void verificarLogin()
    {
        StartCoroutine("verificaruser");
    }

    public IEnumerator verificaruser()
    {
        user = usuario.text;
        pass = password.text;
        string urlusing = log + "?user=" + user + "&pass="+pass;
        WWW validate = new WWW(urlusing);
        Debug.Log(urlusing);
        yield return validate;
        if (validate.text.Contains("Bienvenido"))
        {
            cargo.GetComponent<G_user>().name=user;
            cargo.GetComponent<G_user>().pass = pass;
            SceneManager.LoadScene("MenuPrincipal");
        }
        else
        {
            error1.SetActive(true);
        }

    }

    public void verificarRegistro()
    {
        StartCoroutine("registraruser");
    }
    public IEnumerator registraruser()
    {
        if (correo.text==Ccorreo.text && password_r.text== Cpassword_r.text)
        {
            user_r = usuario_r.text;
            pass_r = password_r.text;
            name_r = nombre.text;
            lastname_r = apellido.text;
            correo_r = correo.text;
            string urlusing2 = reg + "?user=" + user_r + "&pass=" + pass_r + "&name=" + name_r + "&lastname=" + lastname_r + "&email=" + correo_r;
            WWW validate2 = new WWW(urlusing2);
            Debug.Log(urlusing2);
            yield return validate2;
            if (validate2.text.Contains("registrado"))
            {
                SceneManager.LoadScene("MenuLogin");
            }
            else if (validate2.text.Contains("usuario repetido"))
            {
                error2.SetActive(true);
            }
        }
        else
        {
            error3.SetActive(true);
            error2.SetActive(false);
        }

    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }

}
