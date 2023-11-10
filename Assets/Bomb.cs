using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer = 1.5f; //Un valor decimal que es el tiempo que tarda en explotar la bomba, se puede (se debe) modificar desde el inspector
    public int score = 100; //Cuanta puntuación base te da una bomba, también modificar desde el inspector

    public ParticleSystem explosion; //El sistema de particulas (un efecto) que contiene la logica de matar al jugador
    
    private IEnumerator Start() //Convertimos el Start en una corrutina, para usar los metodos de parar el tiempo
    {
        yield return new WaitForSeconds(timer); //Espera el tiempo puesto en timer
        
        GameManager.Instance.ResetCombo(); //Resetea el combo ya que no has conseguido cogerla
        Instantiate(explosion, transform.position, Quaternion.identity); //Crea en la escena una copia de las particulas, que contienen la logica de matar al jugador (si lo toca)
        Destroy(gameObject); //Se autodestruye
    }

    private void OnTriggerEnter2D(Collider2D other) //Recolectar bomba, esto se llama cuando algo entra en un collisionador con la opción Trigger activado (esto hace que no choque, solo detecte)
    {
        if (!other.gameObject.CompareTag("Player")) return; //Si miramos su "tag" y no pone Player dejamos de ejecutar
        
        GameManager.Instance.AddCombo(); //Si si que es player llamamos a AddCombo
        GameManager.Instance.AddScore(score * GameManager.Instance.combo); //Añadimos la puntuación multiplicada por el combo actual
        GameManager.Instance.ShakeCamera(.1f, .30f); //Temblamos la camara
        Destroy(gameObject); //Destruimos la bomba
    }
}
