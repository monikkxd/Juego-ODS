using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CasillasWinScript : MonoBehaviour
{
    [SerializeField] private int objetosEnCuadricula;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject Transici�n;

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
            Transici�n.SetActive(true);
            Invoke("CambioEscena", 1.5f);
            print("Victoria");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Edificio"))
        {
            objetosEnCuadricula += 1;
            Debug.Log("Objeto En Cuadr�cula");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Edificio"))
        {
            objetosEnCuadricula -= 1;
            Debug.Log("Objeto Fuera de Cuadr�cula");
        }
    }

    void CambioEscena()
    {
        SceneManager.LoadScene("MoniFinal");
    }



}
