using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_spawner : MonoBehaviour
{
    public Object gomitaObj;
    private GameObject referenciaGomitaObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && referenciaGomitaObj == null)
        {

             referenciaGomitaObj = Instantiate(gomitaObj, transform.position, Quaternion.identity) as GameObject;

        }

    }
}
