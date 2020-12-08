using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulsoBola : MonoBehaviour
{
    int numeroParaMeterSeno;
    float numeroImpulsador;
    Rigidbody rb_bolaBlanca;
    Transform t_posicionCamara;
    Vector3 v3_fuerzaPaPegar;

    // Start is called before the first frame update
    void Start()
    {
        rb_bolaBlanca = GameObject.FindGameObjectWithTag("bolaBlanca").GetComponent<Rigidbody>();
        t_posicionCamara = GameObject.FindGameObjectWithTag("posicionCamara").GetComponent<Transform>();        
    }

    // Update is called once per frame
    void Update()
    {
        numeroParaMeterSeno++;
        numeroImpulsador = Mathf.Abs(Mathf.Sin(numeroParaMeterSeno));
        v3_fuerzaPaPegar = new Vector3(1, 1, 1) * numeroImpulsador;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb_bolaBlanca.AddForce((t_posicionCamara.forward * 100) - (v3_fuerzaPaPegar * 100));
            
        }

        //print(numeroImpulsador);
    }
}
