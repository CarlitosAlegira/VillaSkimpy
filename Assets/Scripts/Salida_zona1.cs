using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Salida_zona1 : MonoBehaviour
{
    public GameObject mostrar;
    bool si,no;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            mostrar.SetActive(true);
            other.GetComponent<Movimeinto>().menu=true;
            Cursor.lockState = CursorLockMode.None;
            if (si)
            {
                mostrar.SetActive(false);
                other.GetComponent<Movimeinto>().menu = false;
                Cursor.lockState = CursorLockMode.Locked;
                other.GetComponent<Transform>().SetPositionAndRotation(new Vector3(350,55,30),other.transform.rotation);
                EditorSceneManager.LoadScene(2);
                si = false;
                no = false;
            }
            else if(no)
            {
                mostrar.SetActive(false);
                other.GetComponent<Movimeinto>().menu = false;
                Cursor.lockState = CursorLockMode.Locked;
                si = false;
                no = false;
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
        }
    }
}
