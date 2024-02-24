using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CocinerosSpawner cocinerosSpawner; // Aseg�rate de asignar el objeto CocinerosSpawner en el Inspector
    public Cliente cliente; // Aseg�rate de asignar el objeto CocinerosSpawner en el Inspector

    void Start()
    {
        // Llama a la funci�n SpawnObject en el CocinerosSpawner cada 8 segundos
        InvokeRepeating("SpawnCamarero", 0f, 8f);
    }

    void SpawnCamarero()
    {
        cocinerosSpawner.SpawnObject();
    }

    
}
