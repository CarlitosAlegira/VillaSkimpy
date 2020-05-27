using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartaFinal : MonoBehaviour
{

    public Canvas cartaFinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                cartaFinal.enabled = true;
            }
        }
    }

    public void cargarEscenaFinal()
    {
        SceneManager.LoadScene("Creditos");
    }

}
