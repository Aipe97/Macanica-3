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

    //Se enfoca en la rotacion y rescala del planeta,  y restablece su velocidad
    private void RotatePlanet()
    {
        transform.localScale = Vector3.one *  sizeEsfera; //Modifica la escal del objeto 
        vel_esfera = (5.5f - sizeEsfera);// Ajusta su velocidad deacuedo a su tamaño
        transform.Rotate(Vector3.up, vel_esfera);//Rota el planeta
    }
    //Se enfoca en recibir la informacion del manager de PlanetManager
    public void EditPlanet(float size)
    {
        sizeEsfera = size;//Actualiza el tamaño

        RotatePlanet();
        CheckSize();
    }
    //Revisa el tamaño del objeto para decidir cuantas lunas tiene el objeto
    private void CheckSize() {
        int numLuna = (int)sizeEsfera;//Normaliza el tamaño para tener solo los integers

        if(numLuna!= f_numLunas)//Checa si ahi un cambio en el tamaño
        {
            //Crea o destruye lunas para cual es la diferencia y si es elimnar o crear
            CreateOrDeleteLuna(Mathf.Abs(numLuna-f_numLunas), numLuna>f_numLunas);
        }

        foreach(Luna l in lunas) //Por cada luna se actualiza la posicion de rotacion
        {
            //Recibe el tamaño de la esfera mas un offset y la velocidad de la misma
            l.updatePosEsfera(sizeEsfera+0.5f,vel_esfera);
        }

    }
    //Funcion para añadir o quitar lunas de la lista de lunas
    private void CreateOrDeleteLuna(int dif, bool path)
    {
        if (path) //Add
        {
            for (int i = 0; i < dif; i++)//Por cada uno que se agrega se crea una luna nueva
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
            Destroy(lunas[lunas.Count-1].lunaRef.gameObject);//Se elimina el game object de la luna
            lunas.RemoveAt(lunas.Count-1);//Remueve la ultima luna de la lista
        }
        f_numLunas = lunas.Count;//Actualiza la cantidad de luans que ahi en la lista
    }

    //Clase que define el comportamiento de la luna
    public class Luna
    {
        public float offsetDis;//Offset de distancia de la luna al planeta
        public float angleOffset;//Offset de rotacion
        public Transform planet;//Referencai al planeta al que pertenece
        public Transform lunaRef;//Referencia al gameobject en el mundo

        public void updatePosEsfera(float dis , float vel)
        {
            float angle = (Time.time + angleOffset) * vel; // Calcula el angulo en Rad
            float x1 = Mathf.Cos(angle) * (dis+ offsetDis); //Calcula su posicion en "x" y "y"
            float y1 = Mathf.Sin(angle) * (dis+ offsetDis);

            lunaRef.position = new Vector3(x1, 0.0f, y1) + planet.position; //Actualiza la posicion
        }
    }
}
