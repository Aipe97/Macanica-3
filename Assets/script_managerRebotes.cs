using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_managerRebotes : MonoBehaviour
{
    public static script_managerRebotes instance;

    script_plataformas plataformas;

    Rigidbody selfRigid;
    [SerializeField]
    float fuerza = 200f;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        selfRigid = GetComponent<Rigidbody>();
        selfRigid.AddForce(Vector3.right* fuerza, ForceMode.Force);
        //plataformas = GameObject.FindObjectsOfType<script_plataformas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void variarEscalas()
    {

        /*print(plataformas.Length);
        foreach(script_plataformas plat in plataformas)
        {
            plat.CambiarEscala();
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (plataformas != null)
        {
            script_plataformas temp = collision.gameObject.GetComponent<script_plataformas>();

            if (temp != null && temp!=plataformas)
            {
                plataformas.CambiarEscala();

                plataformas = temp;
            }
        }

        plataformas = collision.gameObject.GetComponent<script_plataformas>();
    }
}
