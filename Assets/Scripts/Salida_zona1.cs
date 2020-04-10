using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Salida_zona1 : MonoBehaviour
{
    public GameObject mostrar;
    [SerializeField] Transform player;
    bool si,no,is_menu;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player" && !is_menu)
        {
            mostrar.SetActive(true);
            other.GetComponent<Movimeinto>().menu=true;
            Cursor.lockState = CursorLockMode.None;

            if (si)
            {
                mostrar.SetActive(false);
                other.GetComponent<Movimeinto>().menu = false;
                Cursor.lockState = CursorLockMode.Locked;
                player.transform.position = new Vector3(0,0,0);
                //EditorSceneManager.LoadScene(2);
                si = false;
                no = false;
                is_menu = true;
            }
            else if(no)
            {
                mostrar.SetActive(false);
                other.GetComponent<Movimeinto>().menu = false;
                Cursor.lockState = CursorLockMode.Locked;
                si = false;
                no = false;
                is_menu = true;
            }
        }
    }
    
    public void respuesta(bool res)
    {
        if (res)
        {
            si = true;
        }
        else
        {
            no = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mostrar.SetActive(false);
            si = false;
            no = false;
            Cursor.lockState = CursorLockMode.Locked;
            is_menu = false;
        }
    }
}
