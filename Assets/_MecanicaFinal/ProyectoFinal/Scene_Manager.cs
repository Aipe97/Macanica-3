using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    List<scrpt_MovimientoArmonico> pelotas;
    public scrpt_MovimientoArmonico refObjeto;
    // Start is called before the first frame update
    void Start()
    {
        pelotas = new List<scrpt_MovimientoArmonico>();
        scrpt_MovimientoArmonico primera = GameObject.FindGameObjectWithTag("esfera").GetComponent<scrpt_MovimientoArmonico>();
        pelotas.Add(primera);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals) && pelotas.Count<5)
        {
            CrearPelota();
        }
    }

    void CrearPelota()
    {
        int pos;
        Vector3 dir= ChecarPosisionYDireccion(out pos);
        scrpt_MovimientoArmonico pelota= Instantiate(refObjeto, dir * pos, Quaternion.identity);

        pelotas.Add(pelota);
    }

    Vector3 ChecarPosisionYDireccion(out int index)
    {
        int count = pelotas.Count+1;
        Vector3 dir= (count % 2 == 0)?Vector3.right:Vector3.left;
        index = count / 2;

        return dir*1.2f;
    }
}

