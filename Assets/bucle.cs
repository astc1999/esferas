using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucle : MonoBehaviour
{
    private GameObject esfera; //variable gameobjet privada
    public bool checkbox;//variable  publica booleana 
    int num;// variable privada tipo entero




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EsferasColores());//crea una rutina de colores para el objeto
    }

    public IEnumerator EsferasColores()// clase para la coleccion de los colores 
    { 
        Color[] color = new Color[6];// matriz de 6 colores
        num = Random.Range(3, 12);//variable numerica aleatoria entre 3 y 12
        Color colorObjeto1 = Color.blue;// se establece color azul al objeto 1
        Color colorObjeto2 = Color.red;// se establece color rojo al objeto 2

        color[0] = Color.yellow;//color 0 es color amarillo
        color[1] = Color.blue;//color 1 es color azul
        color[2] = Color.red;//color 2 es color rojo
        color[3] = Color.green;//color 3 es color verde
        color[4] = Color.gray;//color 4 es color gris
        color[5] = Color.cyan;//color 5 es color cyan

        if (checkbox == true)// si el booleano es verdadero entonces se ejecuta los parametros
        {

            for (int x = 0; x < num; x++)// bucle que genera un numero  de objeto aleatorio entre3 y 12  en eje x
            {
                GameObject objeto1 = null;//esferas igual a nulo
                for (int y = 0; y < num; y++)//bucle que genera un numero de objeto aleatorio entre 3 y 12 en eje y
                {
                    GameObject esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);//se crea un objeto en el juego tipo esfera
                    esfera.GetComponent<Renderer>().material.color = color[Random.Range(0,color.Length)];//coge las esferas creadas y les va dando colores aleatorios de acuerdo a la matriz
                    esfera.transform.position =new Vector3(y, x, 0);// posicion de las esferas en x ,y,z
                    Comparadora comparar = new Comparadora();//funcion que compara los datos viejos con los recientes y genera una accion
                    if (objeto1 != null)// si el objeto1 o la esfera1 es diferente de nulo 
                    {
                        colorObjeto2 = esfera.GetComponent<Renderer>().material.color;// color a usar para el objeto2 
                        colorObjeto1 = objeto1.GetComponent<Renderer>().material.color;//color a usar para el objeto1
                        esfera.GetComponent<Renderer>().material.color= comparar.colorActual(colorObjeto1,colorObjeto2);// compara el color del objeto 1 y el objeto 2
                        objeto1.GetComponent<Renderer>().material.color = comparar.colorAnterior(colorObjeto1, colorObjeto2);// compara el color de los 2 objetos
                    }

                    yield return new WaitForSeconds(0.5f); // espera y retorna cada cierto tiempo
                    objeto1 = esfera;// objeto1 es igual a esfera
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
public class Comparadora// clase publica comparadora
{

    public Color colorN = Color.black;// variable publica para establecer color negro
    // Start is called before the first frame update
    public Color colorAnterior(Color antrior, Color neu)//clase comparadora del color anterior y el nuevo
    {
        if (antrior == neu)// si color anterior es igual al nuevo
        {
            antrior = colorN;///si el color anterior y el nuevo son iguales entonces el color de los objetos se cambian a negro
        }
        return antrior;//sigue el proceso de verificar 
  
    }
   public Color colorActual(Color antrior, Color neu)//clase comparadora del color anterior y el nuevo
    {
        if (antrior == neu)// si color anterior es igual al nuevo
        {
            neu= colorN;//si el color anterior y el nuevo son iguales entonces el color de los objetos se cambian a negro
        }
        return neu;//sigue el proceso de verificar
    }
        // Update is called once per frame
        void Update()
    {

    }
}




