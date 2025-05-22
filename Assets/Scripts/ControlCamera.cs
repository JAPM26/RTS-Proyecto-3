using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCamera : MonoBehaviour
{
    private InputAction movimiento;
    private InputAction rotacion;
    private Transform tm;
    public float velocidad = 40;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movimiento = InputSystem.actions.FindAction("Move");
        rotacion = InputSystem.actions.FindAction("Rotation");
        tm = transform.Find("yaw");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){   
            //Leer los valores de movimiento y rotacion
            Vector2 vectorMovimiento = movimiento.ReadValue<Vector2>();
            float cambioRotacion = rotacion.ReadValue<float>();

            //Aplicar cambios a la camara
            tm.Rotate(0,cambioRotacion,0);
            Vector3 movimientoRotado = tm.rotation * new Vector3(vectorMovimiento.x,0,vectorMovimiento.y);
            transform.Translate(Time.deltaTime * velocidad * movimientoRotado);

            
        }
    }
}
