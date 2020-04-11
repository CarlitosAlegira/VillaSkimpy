using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    Rect pos;
    bool mes;
    // Start is called before the first frame update
    private void OnGUI()
    {
        if (mes)
        {
            pos = new Rect(Screen.width / 2 - 50, 4 * Screen.height / 5, Screen.width, Screen.height);
            GUI.Label(pos, "Presione E para recoger");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            mes = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameObject.name == "Hacha") 
                {
                    other.GetComponent<Combate>().Weapon = 3;
                }
                else if (gameObject.name == "Bate")
                {
                    other.GetComponent<Combate>().Weapon = 2;
                }
                else if (gameObject.name == "Maza")
                {
                    other.GetComponent<Combate>().Weapon = 4;
                }

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        mes = false;
    }
}
