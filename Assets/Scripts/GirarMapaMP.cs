﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarMapaMP : MonoBehaviour
{

    void Start()
    {
        
    }

  
    void Update()
    {

        transform.Rotate(new Vector3(0, 0.1f, 0));
    }
}
