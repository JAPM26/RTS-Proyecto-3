using System.Collections.Generic;
using UnityEngine;

public class OtroMouseSeleccion : MonoBehaviour//NUEVO SCRIPT DE SELECCION (Seleccion de caja)
{
    private bool isSelecting = false;
    private Vector3 startMousePosition;
    private Vector3 endMousePosition;
    private Rect selectionRect;
    private List<GameObject> selectedObjects = new List<GameObject>();


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Obtiene el input del mouse
        {
            isSelecting = true;
            startMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) //Obtiene el input del mouse cuando se levanta
        {
            isSelecting = false;
            SelectObjects();
        }

        if (isSelecting)//Si se esta seleccionado toma la ultima posicion del mouse para delimitar el area del cuadrado
        {
            endMousePosition = Input.mousePosition;
        }
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            Rect rect = new Rect(
                Mathf.Min(startMousePosition.x, endMousePosition.x),
                Screen.height - Mathf.Max(startMousePosition.y, endMousePosition.y),
                Mathf.Abs(endMousePosition.x - startMousePosition.x),
                Mathf.Abs(endMousePosition.y - startMousePosition.y)
            );
            GUI.Box(rect, "");//Va creando el cuadrado de seleccion en la pantalla de manera visual
        }
    }

    void SelectObjects(){
        if(selectedObjects != null){
            foreach (GameObject obj in selectedObjects){
                Renderer render = obj.GetComponent<Renderer>();
                if(render != null){
                    obj.GetComponent<Renderer>().material.color = Color.gray;//si no estan dentro de la lista los objetos los cambia de color y deselecciona
                }
                MoveUnidad move = obj.GetComponent<MoveUnidad>();
                if(move != null){
                    move.seleccionados = false;
                }
                Edificio edificio = obj.GetComponent<Edificio>();
                if(edificio != null){
                    edificio.activo = false;
                }
            }
        }
        selectedObjects.Clear();
        selectionRect = new Rect(
            Mathf.Min(startMousePosition.x, endMousePosition.x),
            Mathf.Min(startMousePosition.y, endMousePosition.y),
            Mathf.Abs(endMousePosition.x - startMousePosition.x),
            Mathf.Abs(endMousePosition.y - startMousePosition.y)
        );

        foreach (GameObject obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None)){
            Vector3 screenPos = Camera.main.WorldToScreenPoint(obj.transform.position);
            if (selectionRect.Contains(screenPos)){
                selectedObjects.Add(obj);
                // Puedes marcar visualmente los objetos seleccionados
                Renderer render = obj.GetComponent<Renderer>();
                if(render != null){
                    obj.GetComponent<Renderer>().material.color = Color.red;
                }
                MoveUnidad move = obj.GetComponent<MoveUnidad>();
                if(move != null){
                    move.seleccionados = true;
                }
                Edificio edificio = obj.GetComponent<Edificio>();
                if(edificio != null){
                    edificio.activo = true;
                }
            }
        }
    }
}