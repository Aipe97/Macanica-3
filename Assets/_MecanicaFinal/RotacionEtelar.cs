using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEtelar : MonoBehaviour
{
    public Transform LunaObj;
    float vel_esfera=1;
    float sizeEsfera=1;
    int f_numLunas = 0;

    List<Luna> lunas;
    // Start is called before the first frame update
    void Start()
    {
        lunas = new List<Luna>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RotatePlanet()
    {
        transform.localScale = Vector3.one *  sizeEsfera;
        vel_esfera = (5.5f - sizeEsfera);
        transform.Rotate(Vector3.up, vel_esfera);
    }

    public void EditPlanet(float size)
    {
        sizeEsfera = size;

        RotatePlanet();
        CheckSize();
    }

    private void CheckSize() {
        int numLuna = (int)sizeEsfera;

        if(numLuna!= f_numLunas)
        {
            CreateOrDeleteLuna(Mathf.Abs(numLuna-f_numLunas), numLuna>f_numLunas);
        }

        foreach(Luna l in lunas)
        {
            l.updatePosEsfera(sizeEsfera+0.5f,vel_esfera);
        }

    }

    private void CreateOrDeleteLuna(int dif, bool path)
    {
        if (path) //Add
        {
            print(dif);
            for (int i = 0; i < dif; i++)
            {
                Luna newMoon = new Luna();
                newMoon.angleOffset = (Time.time)+(0.6f * lunas.Count);
                newMoon.planet = transform;
                newMoon.offsetDis = 1.0f * lunas.Count;
                newMoon.lunaRef = Instantiate(LunaObj, transform.position, Quaternion.identity);

                lunas.Add(newMoon);
            }

            
        }
        else if(lunas.Count>0) //Delete
        {
            Destroy(lunas[lunas.Count-1].lunaRef.gameObject);
            lunas.RemoveAt(lunas.Count-1);
        }
        f_numLunas = lunas.Count;
    }

    public class Luna
    {
        public float offsetDis;
        public float angleOffset;
        public Transform planet;
        public Transform lunaRef;

        public void updatePosEsfera(float dis , float vel)
        {
            float angle = (Time.time + angleOffset) * vel;
            float x1 = Mathf.Cos(angle) * (dis+ offsetDis);
            float y1 = Mathf.Sin(angle) * (dis+ offsetDis);

            lunaRef.position = new Vector3(x1, 0.0f, y1) + planet.position;
        }
    }
}
