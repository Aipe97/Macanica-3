using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_plataformas : MonoBehaviour
{
    Vector3 escalaInicial;

    float rangoVaricion=2;

    // Start is called before the first frame update
    void Start()
    {
        escalaInicial = transform.parent.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarEscala()
    {
        float cambio = Random.Range(0f, rangoVaricion);
        Vector3 temp = escalaInicial;
        temp.y += cambio;
        print(temp);
        transform.parent.localScale = temp;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            script_managerRebotes.instance.variarEscalas();
        }   
    }*/
}
