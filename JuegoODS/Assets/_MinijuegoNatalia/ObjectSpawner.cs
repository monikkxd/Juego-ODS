using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array de prefabs de obstáculos
    public Transform[] lanes; // Array de transformaciones que marcan los carriles
    public float spawnInterval = 2f; // Intervalo de generación de obstáculos
    public float spawnOffset = 5f; // Desplazamiento de la generación de obstáculos

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            GenerateObstacle();
            timer = 0f;
        }
    }

    void GenerateObstacle()
    {
        int laneIndex = Random.Range(0, lanes.Length); // Selecciona un carril aleatorio
        Vector3 spawnPosition = lanes[laneIndex].position + Vector3.forward * spawnOffset; // Calcula la posición de generación

        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]; // Selecciona un obstáculo aleatorio del array
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity); // Genera el obstáculo en la posición calculada
    }
}

