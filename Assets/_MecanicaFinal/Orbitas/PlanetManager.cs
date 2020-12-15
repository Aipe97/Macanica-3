using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public RotacionEtelar planeta1, planeta2;
    float sizeEsfera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        sizeEsfera += x * Time.deltaTime;

        sizeEsfera = Mathf.Clamp(sizeEsfera, 0.5f, 5f);

        planeta1.EditPlanet(sizeEsfera);
        planeta2.EditPlanet((5.5f-sizeEsfera));
    }
}
