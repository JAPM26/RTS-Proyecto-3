using UnityEngine;
using System.Collections.Generic;

public class OnClickMouse : MonoBehaviour///OBSOLETO//CODIGO ESPAGUETI//SOLO ALGUNAS FUNCIONES SON RELEVANTES
{
    private Camera camer;
    private GameObject seleccion;
    private GameObject ultimoObjeto = null;

    [HideInInspector] public List<GameObject> ultimosObjetos;
    [HideInInspector] public Vector3 puntoImpacto;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camer = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Definicion y dibujado del raycast
        Ray raycastCamera = camer.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raycastCamera.origin, raycastCamera.direction * 20, Color.blue);
        //Al hacer click cambia el color de material del objeto (Seleccion multiple con ctrl)
        if(Physics.Raycast(raycastCamera, out RaycastHit hit, 100) && Input.GetMouseButtonDown(0) && (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))){
            if(seleccion != null){
                Renderer renderer = seleccion.GetComponent<Renderer>();
                if(renderer != null){
                    seleccion.GetComponent<Renderer>().material.color = Color.gray;
                }
                Edificio edificio = seleccion.GetComponent<Edificio>();
                if(edificio != null){
                    edificio.activo = false;
                }
            }
            seleccion = hit.collider.gameObject;
            ultimosObjetos.Add(seleccion);
            if(ultimosObjetos != null){
                foreach (GameObject multSelection in ultimosObjetos){
                //Cambia el color por cada objeto en la lista
                Renderer renderer = multSelection.GetComponent<Renderer>();
                if(renderer != null){
                    multSelection.GetComponent<Renderer>().material.color = Color.red;
                }
                //Si las unidadades se seleccionan hacer que se muevan
                MoveUnidad move = multSelection.GetComponent<MoveUnidad>();
                    if(move != null){
                        move.seleccionados = true;
                    }
                }
            }
        }
        //Seleccion individual
        else if(Physics.Raycast(raycastCamera, out hit, 100) && Input.GetMouseButtonDown(0)){
            puntoImpacto = hit.point;//toma el punto de impacto que tiene el raycast

            //Cambia el color del objeto que se clickeo
            seleccion = hit.collider.gameObject;
            Renderer renderer = seleccion.GetComponent<Renderer>();
                if(renderer != null){
                    seleccion.GetComponent<Renderer>().material.color = Color.red;
                }
            Edificio edificio = seleccion.GetComponent<Edificio>();

            if(edificio != null){
                edificio.activo = true;
                Debug.Log(edificio.activo);///
            }

            //Se ejecutaria una vez al hacer click, para que el objeto comparado no sea null
            if(ultimoObjeto == null){
                ultimoObjeto = seleccion;
            }

            //Si el nombre del objeto anterior no es igual al seleccionado el objeto anterior cambia el color (Se deselecciona)
            else if(ultimoObjeto.name != seleccion.name){
                Renderer rendere = ultimoObjeto.GetComponent<Renderer>();
                    if(rendere != null){
                    ultimoObjeto.GetComponent<Renderer>().material.color = Color.gray;
                    }
                Edificio edifi = ultimoObjeto.GetComponent<Edificio>();
                if(edifi!= null){
                    edifi.activo = false;
                    Debug.Log(edifi.activo);///
                }
                ultimoObjeto = seleccion;
            }
        }
        else if(Physics.Raycast(raycastCamera, out hit, 100) && Input.GetMouseButtonDown(1)){//Si da click derecho envia el punto de colision para moverse y atacar
            puntoImpacto = hit.point;
        }
        //Si se clickea donde no hay un objeto, hace que se deseleccione todo
        else if(!Physics.Raycast(raycastCamera, out hit, 100) && Input.GetMouseButtonDown(0)){
            if(ultimosObjetos != null){
                foreach (GameObject multSelection in ultimosObjetos){
                    Renderer renderer = seleccion.GetComponent<Renderer>();
                    if(renderer != null){
                    multSelection.GetComponent<Renderer>().material.color = Color.gray;
                    }

                    MoveUnidad move = multSelection.GetComponent<MoveUnidad>();
                    if(move != null){
                        move.seleccionados = false;
                    }
                }
                ultimosObjetos.Clear();
            }
        }
    }
}
