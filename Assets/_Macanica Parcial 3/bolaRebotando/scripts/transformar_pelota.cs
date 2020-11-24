using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformar_pelota : MonoBehaviour
{
    script_managerRebotes stateRef;
    Rigidbody otherBall,plRigid;
    Vector3 otherInitPos= new Vector3(37f,-3f,0f);
    Collider otherColl, plCollider;
    PhysicMaterial playerMat;
    // Start is called before the first frame update
    void Start()
    {
        otherBall = GameObject.FindGameObjectWithTag("Other").GetComponent<Rigidbody>();
        otherColl = otherBall.GetComponent<Collider>();
        //otherInitPos = otherBall.transform.position;
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

    private void PrepareBalls()
    {
        float velocidad = 0f;

        switch (stateRef.currentType)
        {
            case (TiposChoque.Elastico): //e=1
                {
                    isElastic(out velocidad);
                    break;
                }
            case (TiposChoque.Inelastico): //0<e<1
                {
                    isInelastic(out velocidad);
                    break;
                }
            case (TiposChoque.Plastico)://e=0
                {
                    isPlastic(out velocidad);
                    break;
                }
        }

    }

    private void isElastic(out float fnt_speed)
    {
        Vector3 initPos = otherInitPos;
        initPos.x += 5f;

        otherBall.position = initPos;
        float magnitud = plRigid.velocity.magnitude;


        otherBall.AddForce(Vector3.left * magnitud, ForceMode.Impulse);
        fnt_speed = magnitud;
    }

    private void isInelastic(out float fnt_speed)
    {

        Vector3 initPos = otherInitPos;
        initPos.x += 5f;

        otherBall.position = initPos;
        float magnitud = plRigid.velocity.magnitude;

        otherBall.AddForce(Vector3.left * (magnitud/2), ForceMode.Impulse);
        fnt_speed = magnitud/2;
    }

    private void isPlastic(out float fnt_speed)
    {
        otherBall.position = otherInitPos;
        fnt_speed = 0f;
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
            otherBall.velocity = Vector3.zero;

            playerMat.bounciness =(stateRef.currentType== TiposChoque.Plastico) ? 0f: 0.5f;
            PrepareBalls();

        }
    }
}
