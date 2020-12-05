using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrpt_restitucion : MonoBehaviour
{
    Text textoRestitucion;  
    float velocidad1, velocidad2, mew1, mew2;
    

    private void Start()
    {
        textoRestitucion = GameObject.FindGameObjectWithTag("TextoRestitucion").GetComponent<Text>();
        textoRestitucion.text = "" + gameObject.GetComponent<script_managerRebotes>().currentType;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Other"))
        {
            velocidad2 = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            velocidad1 = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Other"))
        {
            mew1 = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            mew2 = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            textoRestitucion.text = "Restitución \n e=" + Mathf.Abs((mew2 - mew1 / velocidad1 - velocidad2));

            /*print("antes " + velocidad1);
            print("despues " + mew1);

            print("antes2 " + velocidad2);
            print("despues2 " + mew2);*/
        }
    }
}
