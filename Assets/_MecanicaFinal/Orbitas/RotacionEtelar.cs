using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEtelar : MonoBehaviour
{
    public Transform LunaObj;
    float vel_esfera = 1;
    float sizeEsfera = 1;
    int f_numLunas = 0;
    double vel_Tangencial = 0;
    double vel_LunAngular = 0;
    double hzLunares;


    List<Luna> lunas;
    // Start is called before the first frame update
    void Start()
    {
        lunas = new List<Luna>();
    }

    //Se enfoca en la rotacion y rescala del planeta,  y restablece su velocidad
    private void RotatePlanet()
    {
        transform.localScale = Vector3.one * sizeEsfera; //Modifica la escal del objeto 
        vel_esfera = (5.5f - sizeEsfera);// Ajusta su velocidad deacuedo a su tamaño
        transform.Rotate(Vector3.up, vel_esfera);//Rota el planeta
    }

    public double GetVelTangencial() //Da la velocidad tangencial de la superficie del planeta
    {
        //     7.2      =   1Hz
        //vel_esfera    =   ???

        vel_Tangencial = 2 * 3.1416 * (transform.localScale.x / 2) * (vel_esfera / 7.2);

        return vel_Tangencial;
    }
    public double GetRadius() //Da la velocidad tangencial de la superficie del planeta
    {
        return transform.localScale.x/2;
    }
    public double GetHz() //Da la velocidad tangencial de la superficie del planeta
    {
        return (vel_esfera / 7.2);
    }

    //Se enfoca en recibir la informacion del manager de PlanetManager
    public void EditPlanet(float size)
    {
        sizeEsfera = size;//Actualiza el tamaño

        RotatePlanet();
        CheckSize();
    }
    //Revisa el tamaño del objeto para decidir cuantas lunas tiene el objeto
    private void CheckSize()
    {
        int numLuna = (int)(sizeEsfera/0.05f);//Normaliza el tamaño para tener solo los integers
        print(numLuna);

        if (numLuna != f_numLunas)//Checa si ahi un cambio en el tamaño
        {
            //Crea o destruye lunas para cual es la diferencia y si es elimnar o crear
            CreateOrDeleteLuna(Mathf.Abs(numLuna - f_numLunas), numLuna > f_numLunas);
        }

        foreach (Luna l in lunas) //Por cada luna se actualiza la posicion de rotacion
        {
            //Recibe el tamaño de la esfera mas un offset y la velocidad de la misma
            l.updatePosEsfera(sizeEsfera + 0.5f, vel_esfera);
            vel_LunAngular = l.GetVelAngular();
            hzLunares = l.GetLunarHz();
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
                newMoon.angleOffset = (Time.fixedTime) + (0.6f * lunas.Count);
                newMoon.planet = transform;
                newMoon.offsetDis = 1.0f * lunas.Count;
                newMoon.lunaRef = Instantiate(LunaObj, transform.position, Quaternion.identity);

                lunas.Add(newMoon);
            }


        }
        else if (lunas.Count > 0) //Delete
        {
            Destroy(lunas[lunas.Count - 1].lunaRef.gameObject);//Se elimina el game object de la luna
            lunas.RemoveAt(lunas.Count - 1);//Remueve la ultima luna de la lista
        }
        f_numLunas = lunas.Count;//Actualiza la cantidad de luans que ahi en la lista
    }

    public double regresarVelAng() //envia este valor al otro codigo para mostrarlo en pantalla
    {
        return vel_LunAngular;
    }

    public double regresarLunarHz() //envia este valor al otro codigo para mostrarlo en pantalla
    {
        return hzLunares;
    }

    //Clase que define el comportamiento de la luna
    public class Luna
    {

        public float offsetDis;//Offset de distancia de la luna al planeta
        public float angleOffset;//Offset de rotacion
        public Transform planet;//Referencai al planeta al que pertenece
        public Transform lunaRef;//Referencia al gameobject en el mundo
        float vel_lunar = 0;
        float vel_planeta = 0;
        float randomParaY = Random.Range(-4.0f, 4.0f);

        public void updatePosEsfera(float disDelPlaneta, float velPlaneta)
        {
            //Time.fixedTime == 50 calls per second
            //Time.fixedTime * 7.2 == 1 rotation per second
            //50 calls * 7.2 == == 1 rotation per second
            //360 calls per second == 1 rotation per second

            float angle = (Time.fixedTime + angleOffset) * velPlaneta; // Calcula el angulo en Rad
                         //(50 * velPlaneta)                           // angleOffset es irrelevante en este calculo

            //omega = cambio de rotacion / cambio de tiempo

            vel_lunar = velPlaneta; //Despues de pasarme horas despejando y remplazando valores apenas me doy cuenta que la velocidad de las lunas es la misma que la del planeta

            float x1 = Mathf.Cos(angle) * (disDelPlaneta + offsetDis); //Calcula su posicion en "x" y "y"
            float z1 = Mathf.Sin(angle) * (disDelPlaneta + offsetDis);
            float y1 = Mathf.Sin(angle) * randomParaY;

            lunaRef.position = new Vector3(x1, y1, z1) + planet.position; //Actualiza la posicion
            vel_planeta = velPlaneta;
        }

        public float GetVelAngular()
        {
            return vel_lunar;
        }

        public double GetLunarHz()
        {
            //50 * 7.2 = 1Hz
            //50 *  velPlaneta = ?
            return 50 * vel_planeta;            
        }
    }
    
}
