using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpt_zoomCamara : MonoBehaviour
{
    Transform esfera;
    bool zoomActivo = false;
    public bool zoomInOut=true;
    Transform mainCamera;
    Vector3 posOriginal;

    float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
        posOriginal = GameObject.FindGameObjectWithTag("posicionCamara").transform.position;
        esfera = GetComponentInChildren<scrpt_MovimientoArmonico>().transform; //guarda el tranform del hijo [1] o sea la esfera
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomActivo)
        {
            float dir = (zoomInOut) ? Time.deltaTime : -Time.deltaTime;
            counter += dir;
            mainCamera.position = Vector3.Lerp(esfera.position + new Vector3(0, 0, -2.0f), posOriginal, 1 - counter);//regresa la camara a la posicion original
            counter = Mathf.Clamp(counter, 0.0f, 1.0f);

            zoomActivo = counter > 0f;
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
