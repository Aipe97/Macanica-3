using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using TMPro;
using System;

public class scrpt_fuerzaSlider : MonoBehaviour
{
    [SerializeField]
    private int iI_segundosIniciales;
    private int iI_segundosActuales;
    public Slider ui_oxigenoSlider;
    public Gradient ui_colorSliderGradient;

    private bool direccionSlider;



    // Start is called before the first frame update
    void Start()
    {
        direccionSlider = true;
        fnt_iniciarTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fnt_iniciarTimer()
    {
        iI_segundosActuales = iI_segundosIniciales;
        fnt_mostrarTiempo(iI_segundosActuales);
        Invoke("updateTimer", 1f);
    }

    public void updateTimer()
    {

        if (direccionSlider)
        {
            iI_segundosActuales--;
        }
        else {
            iI_segundosActuales++;
        }


        /*
        if (iI_segundosActuales < 0)
        {

            //endGame
            //ui_timerText.text = "Se acabo el tiempo";
            //CancelInvoke();
            //direccionSlider = false;



            return;

        }
        else if (ui_oxigenoSlider.value <= 0)
        {
            //ui_oxigenoSlider.value aumentar en uno
            direccionSlider = false;
        }
        */


        if (ui_oxigenoSlider.value <= 0)
        {
            direccionSlider = false;
        } else if (ui_oxigenoSlider.value >= 2) {
            direccionSlider = true;
        }


        //ui_timerText = GetComponent<TextMeshProUGUI>();
        
        fnt_mostrarTiempo(iI_segundosActuales);
        Invoke("updateTimer", 1f);

    }


    private void fnt_mostrarTiempo(int pI_segundosActuales)
    {

        //ui_timerText.text = TimeSpan.FromSeconds(pI_segundosActuales).ToString(@"mm\:ss");
        ui_oxigenoSlider.value = Mathf.Clamp(pI_segundosActuales, 0, 2); //60 es el valor máximo

        //ui_oxigenoSlider.fillRect.GetComponent<Image>().color = ui_colorSliderGradient.Evaluate(1.0f - (Mathf.Clamp(pI_segundosActuales, 0.0f, 60.0f) / 60.0f));

        //Debug.Log("Timer: " + (1.0f - (Mathf.Clamp(pI_segundosActuales, 0.0f, 60.0f) / 60.0f)));
        //Debug.Log("Color: " + ui_colorSliderGradient.Evaluate(1.0f - (Mathf.Clamp(pI_segundosActuales, 0.0f, 60.0f) / 60.0f)));
        
    }
}
