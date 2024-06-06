using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CasillasWinScript : MonoBehaviour
{
    [SerializeField] private int objetosEnCuadricula;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject Transición;

    private void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void Update()
    {
        if(objetosEnCuadricula == 4)
        {
            audioSource.enabled = false;
            Transición.SetActive(true);
            Invoke("CambioEscena", 1.5f);
            print("Victoria");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Edificio"))
        {
            objetosEnCuadricula += 1;
            Debug.Log("Objeto En Cuadrícula");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Edificio"))
        {
            objetosEnCuadricula -= 1;
            Debug.Log("Objeto Fuera de Cuadrícula");
        }
    }

    void CambioEscena()
    {
        SceneManager.LoadScene("MoniFinal");
    }



}
