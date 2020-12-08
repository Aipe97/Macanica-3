using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpt_CalculoPoryeccion : MonoBehaviour
{
    [SerializeField]
    Transform direccionProyeccion;
    Ray rayo;
    RaycastHit hit;
    float rad,dot;
    Vector3 cruz, finalDir;
    public float angle;
    bool isHitting;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fnt_CalculateDirection();
    }

    private void fnt_CalculateDirection()
    {
        rayo = new Ray(transform.position, direccionProyeccion.forward);
        isHitting = Physics.Raycast(rayo, out hit);
        if (isHitting)
        {
            if (hit.transform.CompareTag("esfera"))
            {
                Vector3 center2point = (hit.point - hit.transform.position).normalized;
                Vector3 object2ball = (hit.transform.position - transform.position).normalized;

                dot = Vector3.Dot(center2point, object2ball);//Dar con el angulo
                cruz = Vector3.Cross(center2point, object2ball);//Saber direccion

                rad = (Mathf.Acos(dot) * Mathf.Sign(cruz.y)) + (-90f * Mathf.Deg2Rad);
                angle = (rad * Mathf.Rad2Deg);

                finalDir = new Vector3(Mathf.Cos(rad), 0.0f, Mathf.Sin(rad));
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(rayo);

        if (isHitting)
        {
            Ray proyection = new Ray(hit.transform.position, finalDir);
            Gizmos.DrawRay(proyection);
        }
    }
}
