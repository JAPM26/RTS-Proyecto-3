using UnityEngine;

public class Arquero : MoveUnidad
{
    void Start(){
        vida = 10;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destination = agent.destination;
        cama = GameObject.Find("Main Camera");
    }
    public override void attack(){
        if(tiempo > timer){
            Collider[] RangoAtaque = Physics.OverlapSphere(transform.position, 8.0f);
            foreach(Collider ColliderAct in RangoAtaque){
                if(ColliderAct.gameObject.CompareTag("EdificioEnemigo")){
                    Edificio edificio = ColliderAct.GetComponent<Edificio>();
                    //Debug.Log("Hago danio");
                    edificio.vida -= 1;
                }
                else if(ColliderAct.gameObject.CompareTag("UnidadEnemigo")){
                    Enemigos enemigo = ColliderAct.GetComponent<Enemigos>();
                    enemigo.vida -= 1;
                }
                tiempo = 0;
            }
        }
    }
}
