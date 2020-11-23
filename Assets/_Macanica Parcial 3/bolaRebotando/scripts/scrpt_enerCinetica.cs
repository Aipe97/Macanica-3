using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrpt_enerCinetica : MonoBehaviour
{
    public Text textoCinetica;

    // Start is called before the first frame update
    void Start()
    {
        textoCinetica.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        textoCinetica.text = "Ec= " + ((collision.gameObject.GetComponent<Rigidbody>().mass * collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude) / 2).ToString("F3") + "J";
    }
}
