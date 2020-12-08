using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class impulsoBola : MonoBehaviour
{
    
    public float f_fuerzaPostSeno;
    float f_valorSeno;
    Rigidbody rb_bolaBlanca;
    Transform t_posicionCamara;
    Slider ui_slider;

    // Start is called before the first frame update
    void Start()
    {
        rb_bolaBlanca = GetComponent<Rigidbody>();
        t_posicionCamara = GameObject.FindGameObjectWithTag("posicionCamara").transform;
        ui_slider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        f_valorSeno = Mathf.Sin(Time.time);
        f_fuerzaPostSeno = 1 - Mathf.Abs(f_valorSeno);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb_bolaBlanca.AddForce(t_posicionCamara.forward* f_fuerzaPostSeno * 100f);
            
        }

        //print(numeroImpulsador);

        ui_slider.value = Mathf.Clamp(f_valorSeno + 1, 0, 2); //60 es el valor máximo
    }
}
