using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class scpt_movimientoCamara : MonoBehaviour
{

    [SerializeField]
    Transform pelota;
    Rigidbody whiteballRigid;
    Transform camera;
    PositionConstraint constrainPos;
    
    public float dot;
    public float rad;
    float angle=0;
    float distanciaAlObjeto;
    // Start is called before the first frame update
    void Start()
    {
        distanciaAlObjeto = Vector2.Distance(fnt_ObetenerPlanoAereo(transform.position), fnt_ObetenerPlanoAereo(pelota.position));
        dot = Vector2.Dot(fnt_ObetenerPlanoAereo(transform.position).normalized, fnt_ObetenerPlanoAereo(pelota.position).normalized);
        rad = Mathf.Acos(dot) + (180f*Mathf.Deg2Rad);
        camera = Camera.main.transform;
        camera.LookAt(pelota);
        whiteballRigid = pelota.GetComponent<Rigidbody>();
        constrainPos =GetComponent<PositionConstraint>();
        constrainPos.constraintActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        constrainPos.constraintActive = whiteballRigid.velocity.magnitude < 0.1;

        if (constrainPos.constraintActive)
        {
            float h = Input.GetAxis("Horizontal");
            rad += Time.deltaTime * h;
            transform.position = fnt_calcularPosicion();
            transform.LookAt(new Vector3(pelota.transform.position.x, transform.position.y, pelota.transform.position.z));
            camera.position = transform.position;
            camera.LookAt(pelota);
        }
        else
        {
            fnt_RestituirPosicionCamara();
        }


    }

    private Vector2 fnt_ObetenerPlanoAereo(Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }

    private void fnt_RestituirPosicionCamara()
    {
        camera.position = transform.position;
        camera.LookAt(pelota);
    }

    private Vector3 fnt_calcularPosicion()
    {
        
        Vector3 Nposicion = new Vector3(Mathf.Cos(rad), 0.0f, Mathf.Sin(rad))*distanciaAlObjeto;
        Nposicion.y = transform.position.y-pelota.position.y;

        constrainPos.translationOffset = Nposicion;

        Nposicion.y = transform.position.y;
        Nposicion.x += pelota.transform.position.x;
        Nposicion.z += pelota.transform.position.z;

        return Nposicion;
    }
}
