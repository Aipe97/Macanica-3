using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpt_MovimientoArmonico : MonoBehaviour
{
    public Gradient colorPerSec;
    LineRenderer linea;

    public bool randomAmplitud;

    public float peso;
    public float amplitud;

    public float velocidad, velocidadMax;
    public float aceleracion, aceleracionMax;
    public float position;

    public float variable_hooke;
    public float frecuenciaCiclica;

    float initTime;

    // Start is called before the first frame update
    void Start()
    {
        IniciarVariables();

        linea = GetComponent<LineRenderer>();
        linea.positionCount=2;

        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CambiarVariables();

        SetColorDeLinea();
    }

    private void IniciarVariables()
    {
        amplitud = Random.Range(0.1f, 10.0f);
        peso = Random.Range(0.1f, 10.0f);

        variable_hooke = peso * 9.81f / amplitud;
        frecuenciaCiclica = Mathf.Sqrt(variable_hooke / peso);

        aceleracionMax = Mathf.Pow(frecuenciaCiclica, 2) * amplitud;
        velocidadMax = frecuenciaCiclica * amplitud;
    }

    private void CambiarVariables()
    {
        float angulo = (frecuenciaCiclica * (Time.time-initTime)) - 90f;

        position = (amplitud * Mathf.Sin(angulo)) + amplitud;
        Vector3 temp = transform.position;
        temp.y= position;
        transform.position = temp;

        aceleracion = -amplitud * frecuenciaCiclica * Mathf.Sin(angulo);
        velocidad = amplitud * frecuenciaCiclica * Mathf.Cos(angulo);
    }

    private void SetColorDeLinea()
    {
        Color col = colorPerSec.Evaluate(Mathf.Abs(velocidad/velocidadMax));

        linea.SetPosition(0, transform.position);
        Vector3 direccion =  (Vector3.up* velocidad)+ transform.position;
        linea.SetPosition(1, direccion);

        linea.material.color = col;
    }
}
