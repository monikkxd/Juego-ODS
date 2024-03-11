using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CocinerosSpawner cocinerosSpawner; 
    public Cliente cliente; 

    void Start()
    {
        InvokeRepeating("SpawnCamarero", 0f, 8f);
    }

    void SpawnCamarero()
    {
        cocinerosSpawner.SpawnObject();
    }

    
}
