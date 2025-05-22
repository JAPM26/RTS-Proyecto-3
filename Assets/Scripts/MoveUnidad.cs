using UnityEngine;

public class MoveUnidad : MonoBehaviour
{
    [HideInInspector] public Vector3 destination;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent agent;
    [HideInInspector] public GameObject cama;
    
    public bool seleccionados = false;
    public bool atacar = false;
    public float vida = 20;
    
    [HideInInspector] public float timer = 3;
    [HideInInspector] public float tiempo = 0;
    
    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        destination = agent.destination;
        cama = GameObject.Find("Main Camera");
    }

    void Update()
    {
        Vector3 Tremendoimpacto = cama.GetComponent<OnClickMouse>().puntoImpacto;
        // Update destination if the target moves one unit
        
        if(Input.GetMouseButtonDown(0) && seleccionados == true){//Solamente se mueve
            destination = Tremendoimpacto;
            agent.destination = destination;
            //Debug.Log(destination);/////
            atacar = false;
        }
        else if(Input.GetMouseButtonDown(1) && seleccionados == true){//Ataca con el click derecho
            destination = Tremendoimpacto;
            agent.destination = destination;
            //Debug.Log(destination);/////
            atacar = true;
        }
        if(atacar){
            tiempo += Time.deltaTime;
            attack();
        }
    }

    public virtual void attack(){
        if(tiempo > timer){
            Collider[] RangoAtaque = Physics.OverlapSphere(transform.position, 4.0f);
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