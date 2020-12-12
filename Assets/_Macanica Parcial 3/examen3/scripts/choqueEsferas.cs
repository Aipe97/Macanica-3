using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choqueEsferas : MonoBehaviour
{

    //public AudioClip impactado;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AudioSource>().clip = impactado;
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("esfera"))
            GetComponent<AudioSource>().Play();
    }


}
