using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrpt_restitucion : MonoBehaviour
{
    Text textoRestitucion, textoChoqueTipo;
    float velocidad1, velocidad2, mew1, mew2, restitucion;


    private void Start()
    {
        textoRestitucion = GameObject.FindGameObjectWithTag("TextoRestitucion").GetComponent<Text>();
        textoChoqueTipo = GameObject.FindGameObjectWithTag("textoChoqueTipo").GetComponent<Text>();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("esfera"))
        {
            velocidad2 = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            velocidad1 = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("esfera"))
        {
            mew1 = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            mew2 = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            restitucion = Mathf.Abs((mew2 - mew1 / velocidad1 - velocidad2));
            textoRestitucion.text = "Restitución = " + restitucion.ToString("F3") +
                                  "\nVelocidad =   " + velocidad1.ToString("F3") +
                                  "\nMiu =             " + mew1.ToString("F3") +
                                  "\nMasa =          " + gameObject.GetComponent<Rigidbody>().mass;

            if (restitucion > 0.9f)
                textoChoqueTipo.text = "Choque elastico";
            else if (restitucion < 0.1f)
                textoChoqueTipo.text = "Choque plastico";
            else
                textoChoqueTipo.text = "Choque inelastico";


            //e= 1 elastico
            //e= 0 - 1 inelastico
            //e= 0 plastico
        }
    }
}
