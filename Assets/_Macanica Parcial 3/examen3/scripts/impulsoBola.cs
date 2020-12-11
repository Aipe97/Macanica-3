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
    GameObject ui_slider;
    Text textoRestitucion, textoChoqueTipo;

    // Start is called before the first frame update
    void Start()
    {
        rb_bolaBlanca = GetComponent<Rigidbody>();
        t_posicionCamara = GameObject.FindGameObjectWithTag("posicionCamara").transform;
        ui_slider = GameObject.FindGameObjectWithTag("slider");
        textoRestitucion = GameObject.FindGameObjectWithTag("TextoRestitucion").GetComponent<Text>();
        textoChoqueTipo = GameObject.FindGameObjectWithTag("textoChoqueTipo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        f_valorSeno = Mathf.Sin(Time.time);
        f_fuerzaPostSeno = 1 - Mathf.Abs(f_valorSeno);

        if(rb_bolaBlanca.velocity.magnitude < 0.1f)
        {
            textoChoqueTipo.text = "Formula restitucion";
            textoRestitucion.text = "(Miu\u2081 - Miu\u2082) \n ———————————— \n (Velocidad\u2081 - Velocidad\u2082)";
            ui_slider.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb_bolaBlanca.AddForce(t_posicionCamara.forward * f_fuerzaPostSeno * 400f);

            }
        }
        else
            ui_slider.SetActive(false);

        //print(f_valorSeno + 1);

        ui_slider.GetComponent<Slider>().value = Mathf.Clamp(f_valorSeno + 1, 0, 2);
    }
}
