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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        textoCinetica.text = ((collision.gameObject.GetComponent<Rigidbody>().mass * collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude) / 2).ToString("F2") + "J";
    }
}
