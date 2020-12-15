using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEtelar : MonoBehaviour
{
    public Transform trans_esfera1,trans_esfera2;
    float vel_esfera1=1, vel_esfera2=4;
    public float dis_esfera1, dis_esfera2;
    float sizeEsfera1=1;
    // Start is called before the first frame update
    void Start()
    {
    }
    

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        sizeEsfera1 += x* Time.deltaTime;

        sizeEsfera1= Mathf.Clamp(sizeEsfera1, 0.5f, 5f);

        trans_esfera1.localScale = Vector3.one * (5.5f - sizeEsfera1);
        trans_esfera2.localScale = Vector3.one * sizeEsfera1;

        vel_esfera1 = sizeEsfera1;
        vel_esfera2 = (5f-sizeEsfera1);

        //updatePosEsfera(trans_esfera1, vel_esfera1, dis_esfera1);
        //updatePosEsfera(trans_esfera2, vel_esfera2, dis_esfera2);

        trans_esfera1.Rotate(Vector3.up, vel_esfera1);
        trans_esfera2.Rotate(Vector3.up, vel_esfera2);


    }

    private void updatePosEsfera(Transform esfera, float vel, float dis)
    {
        float x1 = Mathf.Cos(Time.time * vel) * dis;
        float y1 = Mathf.Sin(Time.time * vel) * dis;

        esfera.position = new Vector3(x1, 0.0f, y1);
    }
}
