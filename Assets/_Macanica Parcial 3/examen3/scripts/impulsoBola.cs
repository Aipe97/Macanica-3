using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impulsoBola : MonoBehaviour
{
    int numeroParaMeterSeno;
    public float numeroImpulsador;
    Rigidbody rb_bolaBlanca;
    Transform t_posicionCamara;
    Vector3 v3_fuerzaPaPegar;

    // Start is called before the first frame update
    void Start()
    {
        rb_bolaBlanca = GetComponent<Rigidbody>();
        t_posicionCamara = GameObject.FindGameObjectWithTag("posicionCamara").transform;        
    }

    // Update is called once per frame
    void Update()
    {
        numeroImpulsador =1-Mathf.Abs(Mathf.Sin(Time.time));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb_bolaBlanca.AddForce(t_posicionCamara.forward* numeroImpulsador * 100f);
            
        }

        //print(numeroImpulsador);
    }
}
