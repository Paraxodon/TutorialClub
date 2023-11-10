using UnityEngine;
using TMPro; //Necesario para el texto
using UnityEngine.SceneManagement; //Necesario para cargar escenas

public class DeathManager : MonoBehaviour
{
    public TMP_Text currentScoreText, highScoreText; //Referencias al texto de puntuación actual y de puntuación maxima

    private void OnEnable() //Cuando se active esto (cuando el jugador muera y haga setActive(true))
    {
        currentScoreText.text = "Score: " + GameManager.Instance.score; //El texto de score muestra Score: + la puntuación actual
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore"); //El texto de HighScore muestra HighScore: + el valor guardado en PlayerPrefs con nombre HighScore
    }

    private void Update()//Cada frame, pero solo si esto esta activo (por lo que el jugador ha muerto)
    {
        if (Input.GetKeyDown(KeyCode.R)) //Si apretamos R se hace lo de aquí dentro
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Es raro pero basicamente carga la escena, escena actual
        }
    }
}
