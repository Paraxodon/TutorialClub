using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BombSpawner : MonoBehaviour
{

    public Transform[] bombSpawnPoints;
    public GameObject bomb;

    public float bombSpawnRate = 3;
    public float minSpawnRate = .5f;
    public float spawnRateDecrease = .1f;

    public GameObject player;

    private void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    public IEnumerator SpawnBomb()
    {
        Instantiate(bomb, bombSpawnPoints[Random.Range(0, bombSpawnPoints.Length)]);
        yield return new WaitForSeconds(bombSpawnRate);

        if (bombSpawnRate > minSpawnRate)
        {
            bombSpawnRate -= spawnRateDecrease;
        }

        if (player == null) yield break;
        StartCoroutine(SpawnBomb());
    }

}
