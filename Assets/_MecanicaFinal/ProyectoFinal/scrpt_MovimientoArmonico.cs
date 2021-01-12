using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpt_MovimientoArmonico : MonoBehaviour
{
    public Gradient colorPerSec;
    LineRenderer linea;
    public Transform puntoEquilibrio;
    public bool randomAmplitud;

    public float peso;
    public float amplitud;

    public float velocidad, velocidadMax;
    public float aceleracion, aceleracionMax;
    public float position;

    public float variable_hooke;
    public float frecuenciaCiclica;

    float initTime;

    float[] variablesDesignadas = { 1f, 2f, 3f, 4f, 5f };
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
        if (randomAmplitud)
        {
            amplitud = Random.Range(0.1f, 10.0f);
            peso = variablesDesignadas[Random.Range(0, variablesDesignadas.Length - 1)];
        }
        else
        {
            peso = Random.Range(0.1f, 10.0f);
            amplitud = variablesDesignadas[Random.Range(0, variablesDesignadas.Length - 1)];
        }
        variable_hooke = peso * 9.81f / amplitud; // m*a/A
        frecuenciaCiclica = Mathf.Sqrt(variable_hooke / peso); // 

        aceleracionMax = Mathf.Pow(frecuenciaCiclica, 2) * amplitud;
        velocidadMax = frecuenciaCiclica * amplitud;

        puntoEquilibrio.position = (Vector3.up * amplitud) + transform.position;
    }

    private void CambiarVariables()
    {
        float angulo = (frecuenciaCiclica * (Time.time-initTime)) - 90f; // 

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
