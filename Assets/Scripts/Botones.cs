using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void EmpezarJuego(){
        SceneManager.LoadScene("Juego");
    }

    public void Salir(){//Solo sirve en el ejecutable
        Application.Quit();
        Debug.Log("Sali del juego");
    }

    public void VolverMenu(){
        SceneManager.LoadScene("Menu");
    }
}
