using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CocinerosSpawner cocinerosSpawner; // Asegúrate de asignar el objeto CocinerosSpawner en el Inspector
    public Cliente cliente; // Asegúrate de asignar el objeto CocinerosSpawner en el Inspector

    void Start()
    {
        // Llama a la función SpawnObject en el CocinerosSpawner cada 8 segundos
        InvokeRepeating("SpawnCamarero", 0f, 8f);
    }

    void SpawnCamarero()
    {
        cocinerosSpawner.SpawnObject();
    }

    
}
