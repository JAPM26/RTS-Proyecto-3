using UnityEngine;
using UnityEngine.SceneManagement;
public class BasePrincipal : Edificio
{
    void Start(){
        vida = 10;
    }
    void Update(){
        if (vida <= 0){
            SceneManager.LoadScene("Derrota");
        }
    }
}
