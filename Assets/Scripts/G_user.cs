using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_user : MonoBehaviour
{
    public string name;
    public string pass;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
