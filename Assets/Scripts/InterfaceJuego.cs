using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InterfaceJuego : MonoBehaviour
{
    //public Imagen imagenaccion1;
    //public Imagen imagenaccion2;
    //[HideInInspector] public string text; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textmesh;
    float timer = 3;
    float tiempo = 0;
    public int recursos = 100;

    void Update(){
        /*
        MoveUnidad move = GetComponent<MoveUnidad>();
        if(move.seleccionados != null && move.seleccionados = true){
            imagenaccion1.SetActive(true);
            imagenaccion2.SetActive(true);
        }
        else if(move.seleccionados != null && move.seleccionados = false){
            imagenaccion1.SetActive(false);
            imagenaccion2.SetActive(false);
        }*/
        AumentarRecursos();
    }

    public void AumentarRecursos(){
        tiempo += Time.deltaTime;
        if(tiempo > timer){//cada cierto tiempo aniade un recurso al jugador
            recursos += 1;
            tiempo = 0;
            IndicadorRecursos(recursos);
        }
    }

    public void IndicadorRecursos(float recurs){//Cada vez que se actualice la variable de recursos llamar la funcion para que actualice el UI
        textmesh.text = "Recursos: " + recurs.ToString();
    }
}
