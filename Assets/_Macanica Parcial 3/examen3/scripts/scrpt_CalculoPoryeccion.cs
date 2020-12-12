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
    public Vector3 crus;
    bool isHitting, isBall;
    LineRenderer previsualization;

    // Start is called before the first frame update
    void Start()
    {
        previsualization = GetComponent<LineRenderer>();

        previsualization.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fnt_CalculateDirection();
        if (isHitting && isBall)
        {
            DrawPrediction();
        }
        else
        {
            previsualization.positionCount = 0;
        }
    }

    private void fnt_CalculateDirection()
    {
        rayo = new Ray(transform.position, direccionProyeccion.forward);
        isHitting = Physics.Raycast(rayo, out hit);
        if (isHitting)
        {
            isBall = hit.transform.CompareTag("esfera");
            if (isBall)
            {

                Vector3 center2point = (hit.point - hit.transform.position).normalized;
                Vector3 object2ball = (hit.transform.position - transform.position).normalized;

                Vector3 dirRot = Vector3.Cross(hit.transform.position.normalized,transform.position.normalized);
                float degOffset = Mathf.Acos(Vector3.Dot(hit.transform.position.normalized,transform.position.normalized)*Mathf.Sign(dirRot.y)) ;

                dot = Vector3.Dot(center2point, object2ball);//Dar con el angulo
                cruz = Vector3.Cross(center2point, object2ball);//Saber direccion

                rad = (Mathf.Acos(dot) * Mathf.Sign(cruz.y)) + degOffset;
               

                finalDir = new Vector3(Mathf.Cos(rad), 0.0f, Mathf.Sin(rad));


            }
        }
    }

    private void DrawPrediction()
    {
        float mag = (Vector3.Distance(hit.transform.position, transform.position))+1f;
        previsualization.positionCount = (int)mag*4;
        for(int i = 0; i < (int)mag*2; i++)
        {
            Vector3 pos = (direccionProyeccion.forward)/2;
            previsualization.SetPosition(i, (pos * i)+transform.position);
        }
        for (int i = (int)mag*2; i < (int)mag*4; i++)
        {
            Vector3 pos = finalDir/2;
            previsualization.SetPosition(i, (pos * i) + hit.transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(rayo);

        if (isHitting && isBall)
        {
            Ray proyection = new Ray(hit.transform.position, finalDir);
            Gizmos.DrawRay(proyection);
        }
    }
}
