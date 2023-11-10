using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BombSpawner : MonoBehaviour
{
    public Transform[] bombSpawnPoints; //Después de poner a mano los puntos de spawneo los puedes añadir en el inspector aqui para elegirlos al azar
    public GameObject bomb; //El Prefab (objecto copiable) de la bomba

    public float bombSpawnRate = 3; //Cada cuanto aparece una bomba
    public float minSpawnRate = .5f; //Cuanto es el minimo para que aparezca una bomba
    public float spawnRateDecrease = .1f; //Cuanto se reduce el tiempo de spawneo tras una aparición

    public GameObject player; //Una referencia al jugador (hay que ponerla a mano) que nos dice si esta vivo o no mirando si la referencia apunta a algo o no

    private void Start()
    {
        StartCoroutine(SpawnBomb()); //Inicia la corrutina de spawneo de bombas
    }

    public IEnumerator SpawnBomb()
    {
        Instantiate(bomb, bombSpawnPoints[Random.Range(0, bombSpawnPoints.Length)]); //Crea una bomba en un punto al azar entre el punto de spawneo 0 y la longitud de el contenedor de spawns
        yield return new WaitForSeconds(bombSpawnRate); //Espera el tiempo entre spawns

        if (bombSpawnRate > minSpawnRate) //Si el spawnrate es mayor que el minimo haz lo de dentro
        {
            bombSpawnRate -= spawnRateDecrease; //Reducimos el valor del spawneo en spawnRateDecrease
        }

        if (player == null) yield break; //Si el jugador esta muerto (su referencia es nulla por lo que ya no existe) salimos de la corrutina y acaba la ejecución
        StartCoroutine(SpawnBomb()); //Si no, volvemos a empezar este mismo metodo (Recursión)
    }

}
