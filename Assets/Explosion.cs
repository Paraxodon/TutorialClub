using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float deathTime = 0.1f; //Tiempo que dura la explosión, sin esto la colision duraba demasiado y podias morirte sin querer, recomendado ponerlo a 0.1f
    private bool die = false; //Booleano (verdadero o falso) que dice si ha pasado el tiempo de matar al jugador o no
    private IEnumerator Start() //Volvemos a convertir Start en una corrutina
    {
        yield return new WaitForSeconds(deathTime); //Esperamos death time
        die = true; //Ya no es hora de matar
    }

    private void OnTriggerEnter2D(Collider2D other) //Matar jugador
    {
        if (!other.CompareTag("Player") || die) return; //Si el tag de lo que ha entrado NO es Player O ha pasado el tiempo, no matar
        
        other.gameObject.GetComponent<PlayerMovement>().Die(); //Coge la propiedad "PlayerMovement" de player y llama al metodo Die
        
        GameManager.Instance.ShakeCamera(.2f, 1); //Tiembla la camara muy fuerte
    }
}
