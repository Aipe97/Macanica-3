﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetManager : MonoBehaviour
{
    public RotacionEtelar planeta1, planeta2;
    public Text VelTan1, VelTan2, VelAng1, VelAng2;
    float sizeEsfera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() //Esto es para que se mantenga constante sin importar el framerate
    {
        float x = Input.GetAxis("Horizontal");

        sizeEsfera += x * Time.fixedDeltaTime;

        sizeEsfera = Mathf.Clamp(sizeEsfera, 0.5f, 5f);

        planeta1.EditPlanet(sizeEsfera);
        planeta2.EditPlanet((5.5f-sizeEsfera));

        VelTan1.text = "Velocidad Tangencial = " + planeta1.GetVelTangencial().ToString("F4");
        VelTan2.text = "Velocidad Tangencial = " + planeta2.GetVelTangencial().ToString("F4");
        VelAng1.text = "Velocidad Angular = " + planeta1.regresarVelAng().ToString("F4");
        VelAng2.text = "Velocidad Angular = " + planeta2.regresarVelAng().ToString("F4");
    }
}
