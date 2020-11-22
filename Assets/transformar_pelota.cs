using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformar_pelota : MonoBehaviour
{
    script_managerRebotes stateRef;
    Rigidbody otherBall,plRigid;
    Vector3 otherInitPos;
    Collider otherColl, plCollider;
    PhysicMaterial playerMat;
    // Start is called before the first frame update
    void Start()
    {
        otherBall = GameObject.FindGameObjectWithTag("Other").GetComponent<Rigidbody>();
        otherColl = otherBall.GetComponent<Collider>();
        otherInitPos = otherBall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void RestartOtherBall()
    {
        if (otherBall != null)
        {
            otherBall.velocity = Vector3.zero;
            otherBall.transform.position = otherInitPos;
            otherBall.transform.rotation = Quaternion.identity;
        }
    }

    private void PerpareBalls()
    {
        switch (stateRef.currentType)
        {
            case (TiposChoque.Elestico): //e=1
                {
                    isElastic();
                    break;
                }
            case (TiposChoque.Inelastico): //0<e<1
                {
                    isInelastic();
                    break;
                }
            case (TiposChoque.Plastico)://e=0
                {
                    isPlastic();
                    break;
                }
        }

    }

    private void isElastic()
    {
        Vector3 initPos = otherInitPos;
        initPos.x += 10f;

        otherBall.position = initPos;
        float magnitud = plRigid.velocity.magnitude;


        otherBall.AddForce(Vector3.left * magnitud, ForceMode.Impulse);
    }

    private void isInelastic()
    {
        Vector3 initPos = otherInitPos;
        initPos.x += 10f;

        otherBall.position = initPos;
        float magnitud = plRigid.velocity.magnitude;

        otherBall.AddForce(Vector3.left * (magnitud/2), ForceMode.Impulse);
    }

    private void isPlastic()
    {
        otherBall.position = otherInitPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            plCollider = other.GetComponent<Collider>();
            plRigid = other.GetComponent<Rigidbody>();
            playerMat = plCollider.material;
            stateRef = plCollider.GetComponent<script_managerRebotes>();

            playerMat.bounciness = 0f;

            plCollider.material = playerMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMat.bounciness =(stateRef.currentType== TiposChoque.Plastico) ? 0f: 0.5f;


        }
    }
}
