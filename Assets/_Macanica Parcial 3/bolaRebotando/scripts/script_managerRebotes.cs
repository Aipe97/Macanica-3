using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TiposChoque
{
    Elestico, // e=1
    Inelastico, // 0<e<1
    Plastico // e=0
}

public class script_managerRebotes : MonoBehaviour
{
    public static script_managerRebotes instance;



    script_plataformas plataformas;

    Rigidbody selfRigid;
    Collider selfColl;
    PhysicMaterial selfPhysicsMat; //SI NO SE ESTA USANDO PARA NADA SERIA BUENO ELIMINARLO
    [SerializeField]
    float angle=45f;
    [SerializeField]
    float fuerza = 190f;

    public TiposChoque currentType;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        selfColl = GetComponent<Collider>();
        selfPhysicsMat = selfColl.material;
        selfRigid = GetComponent<Rigidbody>();

        float solveAngle = angle * Mathf.Deg2Rad;
        Vector3 directionLunch = new Vector3(Mathf.Cos(solveAngle), Mathf.Sin(solveAngle), 0f);
        selfRigid.AddForce(directionLunch * fuerza, ForceMode.Force);

        currentType = (TiposChoque)Random.Range(0, 2);
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
        if (collision.gameObject.CompareTag("Other"))
        {
            Destroy(this.gameObject, 7f);
        }
        else
        {
            if (plataformas != null)
            {
                script_plataformas temp = collision.gameObject.GetComponent<script_plataformas>();

                if (temp != null && temp != plataformas)
                {
                    plataformas.CambiarEscala();

                    plataformas = temp;
                }
            }

            plataformas = collision.gameObject.GetComponent<script_plataformas>();
        }
    }
}
