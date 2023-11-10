using System;
using System.Collections; //Necesario corruitinas
using UnityEngine;
using TMPro; //Necesario Texto
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Singleton (Una variable para acceder desde otros scripts, solo puede haber uno en la escena)
    
    public TMP_Text scoreText; //Texto de la puntuación actual
    public TMP_Text comboText; //Texto de el combo actual

    public int combo; //Combo, default es 0 
    public int score; //Puntuacion

    private Vector3 initialCameraPosition; //Posicion de la camara para que el temblor de pantalla vaya bien

    private void Awake()
    {
        Instance = this; //Esto inicializa el "Singleton"
    }

    private void Start()
    {
        AddScore(0); //Usa el método para poner la puntuación en 0
        comboText.text = ""; //Pone el texto de combo en "nada"

        initialCameraPosition = Camera.main.transform.position; //Coge la camara principal y guarda su posicion
    }

    public void AddScore(int add) //Método para añadir puntuación
    {
        score += add; //Añade a "score", equivalente a "score = score + add"
        scoreText.text = "Score: " + score; //Pone el texto de score en "Score: " y la puntuación actual
        
        if (score == 0) return; //Si la puntuación actual es 0 (aun no se ha añadido nueva) no animes
        scoreText.GetComponent<Animator>().Play("GotPoints"); //Coge el componente animador y llama a la animación "GotPoints" (luego vuelve a la animación idle ya que en el
                                                                        //Animator en unity se ha puesto una flechita para que vuelva a su animación inicial
    }

    public void AddCombo() //Añade al combo, como siempre se añadirá uno no pide ningún parámetro
    {
        combo++; //Equivalente a combo = combo + 1;
        comboText.text = "Combo: " + combo; //Pone el texto de combo en Combo: y el combo actual
        
        
        if (combo == 0) return; //Lo mismo que antes de la animación ya que este combo es una copia del score
        comboText.GetComponent<Animator>().Play("GotPoints");
    }

    public void ResetCombo() //Resetea el combo a 0 y pone su texto en "nada"
    {
        combo = 0;
        comboText.text = "";
    }

    public void ShakeCamera(float time, float intensity) //Método que se puede llamar con el Singleton para temblar la camara
    {
        StartCoroutine(ShakeCamera_(time, intensity)); //Inicia la corrutina (solo has de saber que en una corrutina puedes parar el tiempo durante x segundos, por eso lo usamos)
    }

    private IEnumerator ShakeCamera_(float time, float intensity) //La corrutina en cuestión
    {
        Transform cam = Camera.main.transform; //Referencia a la posición de la camara para modificarla sin estar llamandola todo el rato
        float t = 0; //tiempo transcurrido
        while (t < time) //mientras que el tiempo transcurrido sea menor al tiempo deseado ejecuta lo que hay aquí dentro
        {
            cam.position = initialCameraPosition + new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), 0); //Añade a la posición inicial un numero aleatorio entre + y - intensidad
            t += Time.deltaTime; //Añade el tiempo de 1 frame a t (esto quiere decir que se llama a todo este codigo una vez por segundo
            yield return null; //Esto es una funcionalidad de la corrutina que espera un frame
        }
        cam.position = initialCameraPosition; //Al terminar el temblor resetea la camara a su posición inicial
    }
}
