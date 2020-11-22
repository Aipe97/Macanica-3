using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrpt_enerCinetica : MonoBehaviour
{
    public Text valorCinetica;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        valorCinetica.text = "(1/2)mv2=" + ((collision.gameObject.GetComponent<Rigidbody>().mass * collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude) / 2).ToString("F2") + "J";
    }
}
