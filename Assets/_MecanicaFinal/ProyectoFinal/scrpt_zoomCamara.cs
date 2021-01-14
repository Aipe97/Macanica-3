using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpt_zoomCamara : MonoBehaviour
{
    Transform esfera;
    bool zoomActivo = false;
    GameObject mainCamera;
    Vector3 posOriginal;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        posOriginal = GameObject.FindGameObjectWithTag("posicionCamara").transform.position;
        esfera = gameObject.transform.GetChild(1); //guarda el tranform del hijo [1] o sea la esfera
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomActivo)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, esfera.position + new Vector3(0, 0, -2.0f), 0.2f); //hace que la camara siga a la pelota
        }
        else if (!zoomActivo && mainCamera.transform.position != posOriginal)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, posOriginal, 0.1f);//regresa la camara a la posicion original
        }
    }
    void OnMouseDown()
    {
        if (!zoomActivo)
        {
            zoomActivo = true;           
        }
        else
        {
            zoomActivo = false;          
        }              
    }
}
