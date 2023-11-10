using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject loseScreen; //Referencia a la pantalla de perdida (hay que ponerla a mano fuera)
    
    public float velocity; //Velocidad del jugador
    public float accelerationFactor; //Factor de aceleración, a mas grande mas rápido acelera
    
    private Vector2 direction; //Esto es para guardar en que dirección hay que moverse
    public Rigidbody2D rb; //Esto será una referencia al Rigidbody (lo que maneja las fisicas)

    private void Awake() //Esto se llama antes del start
    {
        loseScreen.SetActive(false); //Asegura que el loseScreen no este activo antes de iniciar a jugar
    }

    private void Update() //Se llama una vez por frame
    {
        float x = Input.GetAxisRaw("Horizontal"); //Establece una variable x a el valor de Horizontal Input de unity, por default es A D y <- ->
        float y = Input.GetAxisRaw("Vertical"); //Establece una variable y a el valor de Vertical Input de unity, por default es W S y *flechaarriba* *flechaabajo*
        
        direction.Set(x, y); //Pone en una sola variable que contiene un valor x e y (Un vector de dos dimensiones) la x y y anteriores.
        direction.Normalize(); //Una operación matematica para que ir en horizontal no sea mas rapido que ir recto, no hace falta que lo entiendas como tal
    }

    void FixedUpdate() //Una vez por cada frame de fisicas
    {
        rb.velocity = Vector2.Lerp(rb.velocity, direction * velocity, accelerationFactor * Time.deltaTime); //Usa Lerp para mover suavemente el valor de velocidad de la actual a la deseada
        //Fijate que usa la direccion por la velocidad y luego el valor de aceleración por el Time.deltaTime para que vaya bien tengas el frame rate que tengas, no hace falta que lo entiendas no 
        //te preocupes
    }

    public void Die() //Metodo para morir
    {
        int score = GameManager.Instance.score; //Coge el valor de puntuación del Singleton de GameManager
        if (score > PlayerPrefs.GetInt("HighScore")) //Si la puntuación es mayor que el record guardado (usando los PlayerPrefs de Unity) lo cambia para que guarde la nueva puntuación
        {
            PlayerPrefs.SetInt("HighScore", score); //Lo dicho
        }
        
        loseScreen.SetActive(true); //Activa la pantalla de perdida
        
        Destroy(gameObject); //Se autodestruye
    }
}
