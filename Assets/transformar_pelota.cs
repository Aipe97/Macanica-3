using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformar_pelota : MonoBehaviour
{
    public Rigidbody otherBall;
    Vector3 otherInitPos;
    Collider otherColl, plCollider;
    PhysicMaterial playerMat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            plCollider = other.GetComponent<Collider>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
