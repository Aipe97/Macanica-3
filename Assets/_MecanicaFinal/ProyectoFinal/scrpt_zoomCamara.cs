using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrpt_zoomCamara : MonoBehaviour
{
    Transform esfera;
    bool zoomActivo = false;
    public bool zoomInOut= true;
    Transform mainCamera;
    Vector3 posOriginal;
    Text t_amplitud, t_velocidad, t_aceleracion, t_peso, t_RandomA;
    scrpt_MovimientoArmonico referencia;
    GameObject valores;
    float n_amplitud, n_Velocidad, n_aceleracion, n_Peso, n_randomA;
    Canvas c_canvas;

    float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
        posOriginal = GameObject.FindGameObjectWithTag("posicionCamara").transform.position;
        esfera = GetComponentInChildren<scrpt_MovimientoArmonico>().transform; //guarda el tranform del hijo [1] o sea la esfera
        n_amplitud = GetComponentInChildren<scrpt_MovimientoArmonico>().amplitud;      
        n_Peso = GetComponentInChildren<scrpt_MovimientoArmonico>().peso;
        n_randomA = GetComponentInChildren<scrpt_MovimientoArmonico>().variable_hooke;

        c_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        valores = GameObject.FindGameObjectWithTag("Variables_1");
        //valores.SetActive(false);

        t_amplitud = GameObject.FindGameObjectWithTag("Amplitud").GetComponent<Text>();
        t_peso = GameObject.FindGameObjectWithTag("Peso").GetComponent<Text>();
        t_aceleracion = GameObject.FindGameObjectWithTag("Aceleracion").GetComponent<Text>();
        t_velocidad = GameObject.FindGameObjectWithTag("Velocidad").GetComponent<Text>();
        t_RandomA = GameObject.FindGameObjectWithTag("Random").GetComponent<Text>();
        

    }

    void Update()
    {
        if (zoomActivo)
        {
            
            //Agarro los valores aqui porque si no se vuelven 0
            n_Velocidad = GetComponentInChildren<scrpt_MovimientoArmonico>().velocidad;
            n_aceleracion = GetComponentInChildren<scrpt_MovimientoArmonico>().aceleracion;

            //Mostramos los valores en la pantalla y los textos
            valores.SetActive(true);
            t_amplitud.text = "Amplitud: " + n_amplitud.ToString("F2");
            t_velocidad.text = "Velocidad: " + n_Velocidad.ToString("F2");
            t_aceleracion.text = "Aceleracion: " + n_aceleracion.ToString("F2");
            t_peso.text = "Peso: " + n_Peso.ToString("F2");
            t_RandomA.text = "Variable hooke : " + n_randomA.ToString("F2");

            //Acercar la camara de manera natural y alejarla
            float dir = (zoomInOut) ? Time.deltaTime : -Time.deltaTime;
            counter += dir;
            mainCamera.position = Vector3.Lerp(esfera.position + new Vector3(0, 0, -2.0f), posOriginal, 1 - counter);//regresa la camara a la posicion original
            counter = Mathf.Clamp(counter, 0.0f, 1.0f);

            zoomActivo = counter > 0f;
        }
        else
        {
           // valores.SetActive(false);
        }

    }
    void OnMouseDown()
    {
        zoomInOut = !zoomActivo;
        if (!zoomActivo)
        {
            zoomActivo = true;
        }      
    }
}
