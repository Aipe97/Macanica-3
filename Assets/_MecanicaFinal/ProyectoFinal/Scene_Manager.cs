using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager : MonoBehaviour
{
    List<GameObject> pelotas;
    public Object refObjeto;
    // Start is called before the first frame update
    void Start()
    {
        pelotas = new List<GameObject>();
        GameObject primera = GameObject.FindGameObjectWithTag("esfera");
        pelotas.Add(primera);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals) && pelotas.Count<5)
        {
            CrearPelota();
        }
        /*else if (Input.GetMouseButton(0)) //PARA QUE EXISTE ESTO??
        {

        }*/
    }

    void CrearPelota()
    {
        int pos;
        Vector3 dir= ChecarPosisionYDireccion(out pos);
        GameObject pelota= Instantiate(refObjeto, dir * pos, Quaternion.identity) as GameObject;

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

