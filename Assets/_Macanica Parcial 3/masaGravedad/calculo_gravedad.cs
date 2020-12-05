using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculo_gravedad : MonoBehaviour
{
    public Transform objetoDerecho, objetoIzquierdo;
    public Text formula;

    float coeficienteGraveda;
    float fuerzaGravedad;
    public float peso1, peso2;
    float distancia;
    // Start is called before the first frame update
    void Start()
    {
        coeficienteGraveda = 6.67f *Mathf.Pow(10, -11);
        print(coeficienteGraveda);

    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(objetoDerecho.position, objetoIzquierdo.position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Cambio");
            float diferencia = distancia;
            distancia *= 3;

            objetoDerecho.position += Vector3.right * diferencia;
            objetoIzquierdo.position += Vector3.left * diferencia;

            peso1 = peso1 * 3;

        }

       
        fuerzaGravedad = (coeficienteGraveda * peso1 * peso2) / Mathf.Pow(distancia, 2);
        formula.text =String.Format("Fg= (G*m1*m2)/d^2 \n {0} = ({1}*{2}*{3})/{4}^2", fuerzaGravedad.ToString("F2"),coeficienteGraveda.ToString("F2"), peso1,peso2,distancia.ToString("F2"));
    }
}
