using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class scpt_movimientoCamara : MonoBehaviour
{

    [SerializeField]
    Transform pelota;

    Transform camera;
    PositionConstraint constrainPos;

    [Range(0.0f,360.0f)]
    public float seudoAngle=0f;
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
        print(angle* Mathf.Rad2Deg);
        camera = Camera.main.transform;
        camera.LookAt(transform);
        constrainPos=GetComponent<PositionConstraint>();
        constrainPos.constraintActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            constrainPos.constraintActive = false;
            fnt_RestituirPosicionCamara();
        }

        if (!constrainPos.constraintActive)
        {
            float h = Input.GetAxis("Horizontal");
            rad += Time.deltaTime * h;
            transform.position = fnt_calcularPosicion();
            transform.LookAt(new Vector3(pelota.transform.position.x, transform.position.y, pelota.transform.position.z));
            camera.position = transform.position;
            camera.LookAt(pelota);
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
