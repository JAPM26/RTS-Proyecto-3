using UnityEngine;

public class Enemigos : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agente;
    private Transform objetivo;
    public int vida = 10;
    private float timer = 3;
    private float tiempo = 0;

    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (objetivo == null){
        GameObject edificio = GameObject.FindWithTag("Edificio");
            if (edificio != null){
                objetivo = edificio.transform;
            }
        }
    }

    void Update(){
        tiempo += Time.deltaTime;
        agente.SetDestination(objetivo.position);
        if(tiempo > timer){
            attack();
        }
        if(vida < 0){
            Destroy(gameObject);
        }
    }

    public void SetObjetivo(GameObject objetivoJugador)
    {
        if (objetivoJugador != null)
        {
            objetivo = objetivoJugador.transform;
        }
    }

    private void attack(){
        if(tiempo > timer){
            Collider[] RangoAtaque = Physics.OverlapSphere(transform.position, 4.0f);
            foreach(Collider ColliderAct in RangoAtaque){
                if(ColliderAct.gameObject.CompareTag("Edificio")){
                    Edificio edificio = ColliderAct.GetComponent<Edificio>();
                    Debug.Log("Hago danio yo enemigo");
                    edificio.vida -= 1;
                    tiempo = 0;
                }
            }
        }
    }
}