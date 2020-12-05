using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulsoBola : MonoBehaviour
{
    int numeroParaMeterSeno;
    float numeroImpulsador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numeroParaMeterSeno++;
        numeroImpulsador = Mathf.Sin(numeroParaMeterSeno);
        print(numeroImpulsador);
    }
}
