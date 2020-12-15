using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEtelar : MonoBehaviour
{
    public Transform LunaObj;
    float vel_esfera=1;
    public float dis_esfera;
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
        RotatePlanet();
        CheckSize();
    }

    private void RotatePlanet()
    {
        float x = Input.GetAxis("Horizontal");

        sizeEsfera += x * Time.deltaTime;

        sizeEsfera = Mathf.Clamp(sizeEsfera, 0.5f, 5f);

        transform.localScale = Vector3.one *  sizeEsfera;
        vel_esfera = (5f - sizeEsfera);
        transform.Rotate(Vector3.up, vel_esfera);
    }

    private void CheckSize() {
        int numLuna = (int)sizeEsfera;

        if(numLuna!= f_numLunas)
        {
            CreateOrDeleteLuna(Mathf.Abs(numLuna-f_numLunas), numLuna>f_numLunas);
        }

        foreach(Luna l in lunas)
        {
            l.updatePosEsfera(sizeEsfera+0.5f);
        }

    }

    private void CreateOrDeleteLuna(int dif, bool path)
    {
        if (path) //Add
        {
            for (int i = 0; i < dif; i++)
            {
                Luna newMoon = new Luna();
                newMoon.angleOffset = Time.time;
                newMoon.planet = transform;
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

        public float angleOffset;
        public Transform planet;
        public Transform lunaRef;

        public void updatePosEsfera(float dis)
        {
            float x1 = Mathf.Cos(Time.time + angleOffset) * dis;
            float y1 = Mathf.Sin(Time.time + angleOffset) * dis;

            lunaRef.position = new Vector3(x1, 0.0f, y1) + planet.position;
        }
    }
}
