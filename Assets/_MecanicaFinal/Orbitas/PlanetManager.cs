using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetManager : MonoBehaviour
{
    RotacionEtelar[] planetas;
    float[] distancias;
    public Text VelTan1, VelTan2, VelAng1, VelAng2;
    float sizeEsfera;
    // Start is called before the first frame update
    void Start()
    {
        planetas = GetComponentsInChildren<RotacionEtelar>();

        distancias = new float[planetas.Length];

        for (int i = 0; i < distancias.Length; i++)
        {
            distancias[i] = Vector3.Distance(transform.position, planetas[i].transform.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate() //Esto es para que se mantenga constante sin importar el framerate
    {
        float x = Input.GetAxis("Horizontal");

        sizeEsfera += x * Time.fixedDeltaTime;

        sizeEsfera = Mathf.Clamp(sizeEsfera, 0.5f, 5f);

        for(int i = 0; i < planetas.Length; i++)
        {
            float velocidad = Mathf.Abs(((float)i+1.0f) - sizeEsfera);
            planetas[i].EditPlanet(velocidad/transform.localScale.x);
            float angle = (Time.fixedTime + ((float)i * 5f))/ (Mathf.Pow(transform.localScale.x/10f,2f)); // Calcula el angulo en Rad

            float xpos = Mathf.Cos(angle) * distancias[i]; //Calcula su posicion en "x" y "y"
            float ypos = Mathf.Sin(angle) * distancias[i];

            planetas[i].transform.position = new Vector3(xpos, 0.0f, ypos) + transform.position; //Actualiza la posicion
        }

       // planeta1.EditPlanet(sizeEsfera);
       //planeta2.EditPlanet((5.5f-sizeEsfera));

       /* VelTan1.text = "Planeta" +
            "\nVelocidad Tangencial = " + planeta1.GetVelTangencial().ToString("F4") +
            "\nRadio: " + planeta1.GetRadius().ToString("F4") + 
            "\nFrecuencia: " + planeta1.GetHz().ToString("F4");
        VelTan2.text = "Planeta" +
            "\nVelocidad Tangencial = " + planeta2.GetVelTangencial().ToString("F4") +
            "\nRadio: " + planeta2.GetRadius().ToString("F4") +
            "\nFrecuencia: " + planeta2.GetHz().ToString("F4"); ;
        VelAng1.text = "Lunas" +
            "\nVelocidad Angular = " + planeta1.regresarVelAng().ToString("F4") +
            "\nDistancia rotacion: " + planeta1.regresarLunarHz().ToString("F4") + " grados" +
            "\ntiempo recorrido: 1 segundo";
        VelAng2.text = "Lunas" +
            "\nVelocidad Angular = " + planeta2.regresarVelAng().ToString("F4") + 
            "\nDistancia recorrida: " + planeta2.regresarLunarHz().ToString("F4") + " grados" + 
            "\ntiempo recorrido: 1 segundo";*/
    }
}
