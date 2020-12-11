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

    // Start is called before the first frame update
    void Start()
    {
        rb_bolaBlanca = GetComponent<Rigidbody>();
        t_posicionCamara = GameObject.FindGameObjectWithTag("posicionCamara").transform;
        ui_slider = GameObject.FindGameObjectWithTag("slider");
    }

    // Update is called once per frame
    void Update()
    {
        f_valorSeno = Mathf.Sin(Time.time);
        f_fuerzaPostSeno = 1 - Mathf.Abs(f_valorSeno);

        if(rb_bolaBlanca.velocity.magnitude < 0.1f)
        {
            ui_slider.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb_bolaBlanca.AddForce(t_posicionCamara.forward * f_fuerzaPostSeno * 400f);

            }
        }
        else
            ui_slider.SetActive(false);

        //print(f_valorSeno + 1);

        ui_slider.GetComponent<Slider>().value = Mathf.Clamp(f_valorSeno + 1, 0, 2); //60 es el valor máximo
    }
}
