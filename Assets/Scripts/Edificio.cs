using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Edificio : MonoBehaviour
{
    [SerializeField] private GameObject UnidadGenerar;
    [SerializeField] private GameObject PuntoSpawn;
    [HideInInspector] public bool activo = false;
    public GameObject objetivoJugador; // Instancia del jugador

    public InterfaceJuego interfaz;
    int numtotal = 0;
    public float vida = 20;
    float timer = 3;
    float tiempo = 0;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (activo && tiempo > timer && interfaz.recursos >= 10 && numtotal <= 10){
            Instantiate(UnidadGenerar, PuntoSpawn.transform.position, transform.rotation);//crea un prefab (clon)
            numtotal += 1;//Suma en 1 las unidades totales que se han generado Nota: Cada edificio podra generar 10 unidades
            Debug.Log(numtotal);
            tiempo = 0;
            interfaz.recursos -= 10;//Resta recursos al jugador
            interfaz.IndicadorRecursos(interfaz.recursos);//Actualiza la interfaz cuando se crea un nuevo soldado
        }
        else if(gameObject.CompareTag("EdificioEnemigo") && tiempo > timer && numtotal <= 10){//Generacion de enemigos automatica
            Instantiate(UnidadGenerar, PuntoSpawn.transform.position, transform.rotation);//crea un prefab (clon)
            numtotal += 1;
            tiempo = 0;
            Enemigos enemigo = UnidadGenerar.GetComponent<Enemigos>();
            if (enemigo != null)
            {
                objetivoJugador = GameObject.FindWithTag("Edificio");
                Debug.Log("LLendo a: " + objetivoJugador);
                enemigo.SetObjetivo(objetivoJugador);
            }
        }
        if(vida <= 0 ){
            Destroy(gameObject);
        }
    }
}
