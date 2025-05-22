using UnityEngine;

public class Curador : MoveUnidad
{
    void Start(){
        vida = 15;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destination = agent.destination;
        cama = GameObject.Find("Main Camera");
    }

    public override void attack(){
        if(tiempo > timer){
            Collider[] RangoAtaque = Physics.OverlapSphere(transform.position, 8.0f);
            foreach(Collider ColliderAct in RangoAtaque){
                if(ColliderAct.gameObject.CompareTag("Unidad")){
                    MoveUnidad moveunidad = ColliderAct.GetComponent<MoveUnidad>();
                    Debug.Log("Curo");
                    if(moveunidad != null){//Comprueba dentro del area de "ataque" si los objetos como unidad tienen el componente de MoveUnidad
                        if(moveunidad.vida < 20){//Si la vida de la unidad a curar es menos a 10 lo cura, de lo contrario no lo hace
                            moveunidad.vida += 1;
                        }
                    }
                    tiempo = 0;
                }
            }
        }
    }
}
