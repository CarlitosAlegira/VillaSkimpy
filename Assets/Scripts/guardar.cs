using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class guardar : MonoBehaviour
{
    public GameObject canvas,panel_error,panel_n;
    public TextMeshProUGUI nombre_partida;
    string nombre;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvas.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
     public void verificar_datos()
    {
        nombre = nombre_partida.text + "1";
        GameObject.Find("Datos_player").GetComponent<Datos>().nombre_save = nombre;
        Debug.Log(nombre);
        GameObject.Find("Datos_player").GetComponent<Datos>().Guardar();
        panel_n.SetActive(true);
        canvas.SetActive(false);
    }
    public void boton_volver()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movimeinto>().menu = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>().menus2 = false;
        canvas.SetActive(false);
        panel_n.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void error()
    {
        panel_n.SetActive(false);
        canvas.SetActive(true);
        panel_error.SetActive(true);
    }
    public void reescribir()
    {
        PlayerPrefs.DeleteKey(nombre);
        GameObject.Find("Datos_player").GetComponent<Datos>().nombre_save = nombre;
        GameObject.Find("Datos_player").GetComponent<Datos>().Guardar();
        boton_volver();
    }
}
