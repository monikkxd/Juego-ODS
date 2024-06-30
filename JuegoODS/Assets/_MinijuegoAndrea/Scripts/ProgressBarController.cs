using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    // La barra de progreso (Slider)
    public Slider progressBar;

    public GameObject meta;

    // Lista de objetos a eliminar
    public List<GameObject> objectsToDestroy;

    // Cantidad de objetos eliminados
    private int objectsDestroyedCount = 0;

    void Start()
    {
        // Inicializa la barra de progreso
        if (progressBar != null)
        {
            progressBar.maxValue = objectsToDestroy.Count;
            progressBar.value = 0;
        }
    }

    // Llama a esta función para eliminar un objeto
    public void DestroyObject(GameObject obj)
    {
        Debug.Log("progresbar");
         //objectsToDestroy.Remove(obj);
         Destroy(obj);
         objectsDestroyedCount++;
         UpdateProgressBar();
        
    }

    // Actualiza la barra de progreso
    void UpdateProgressBar()
    {
        if (progressBar != null)
        {
            progressBar.value = objectsDestroyedCount;
        }

        if (objectsDestroyedCount >= objectsToDestroy.Count)
        {
            Debug.Log("apagaooooo");
            meta.SetActive(true);
        }
    }
}

