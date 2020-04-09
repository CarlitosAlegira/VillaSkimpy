using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Salida_zona1 : MonoBehaviour
{
    public GameObject mostrar;
    bool ans;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            mostrar.SetActive(true);
            other.GetComponent<Movimeinto>().menu=true;
            Cursor.lockState = CursorLockMode.None;
            if (ans)
            {
                mostrar.SetActive(false);
                other.GetComponent<Movimeinto>().menu = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    
    public void respuesta(bool res)
    {
        if (res)
        {
            EditorSceneManager.LoadScene(2);
        }
        else
        {
            ans = res;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mostrar.SetActive(false);
            ans = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
