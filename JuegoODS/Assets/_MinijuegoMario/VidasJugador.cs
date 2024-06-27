using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidasJugador : MonoBehaviour
{

    public float vidas;
    public MoverYEliminar muerto;
    public bool activar = false;

    public GameObject VidaBn1, VidaBn2, VidaBn3, VidaBn4;
    public GameObject VidaMal1, VidaMal2, VidaMal3, VidaMal4;
    public GameObject hasPerdido;
    public GameObject raton;

    void Start()
    {
        vidas = 4f;
        Debug.Log(vidas);
        VidaBn1.SetActive(true);
        VidaBn2.SetActive(true);
        VidaBn3.SetActive(true);
        VidaBn4.SetActive(true);

        VidaMal1.SetActive(false);
        VidaMal2.SetActive(false);
        VidaMal3.SetActive(false);
        VidaMal4.SetActive(false);

        hasPerdido.SetActive(false);
        //raton.SetActive(false);
    }

    void Update()
    {
        if (vidas==4)
        {
            VidaBn1.SetActive(true);
            VidaBn2.SetActive(true);
            VidaBn3.SetActive(true);
            VidaBn4.SetActive(true);
        }
        if (vidas == 3)
        {
            VidaBn1.SetActive(false);
            VidaMal1.SetActive(true);
            VidaBn2.SetActive(true);
            VidaBn3.SetActive(true);
            VidaBn4.SetActive(true);
        }
        if (vidas == 2)
        {
            VidaBn1.SetActive(false);
            VidaMal1.SetActive(true);
            VidaBn2.SetActive(false);
            VidaMal2.SetActive(true);
            VidaBn3.SetActive(true);
            VidaBn4.SetActive(true);
        }
        if (vidas == 1)
        {
            VidaBn1.SetActive(false);
            VidaMal1.SetActive(true);
            VidaBn2.SetActive(false);
            VidaMal2.SetActive(true);
            VidaBn3.SetActive(false);
            VidaMal3.SetActive(true);
            VidaBn4.SetActive(true);
        }
        if (vidas == 0)
        {
            VidaBn1.SetActive(false);
            VidaMal1.SetActive(true);
            VidaBn2.SetActive(false);
            VidaMal2.SetActive(true);
            VidaBn3.SetActive(false);
            VidaMal3.SetActive(true);
            VidaBn4.SetActive(false);
            VidaMal4.SetActive(true);

            Time.timeScale = 0;
            hasPerdido.SetActive(true);
            raton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("CargoEscena");
                //AQUÍ IRÍA EL CAMBIO DE ESCENA
                //SceneManager.LoadScene("...");
            }
        }

    }

    void QuitarVidas()
    {
        vidas = vidas - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plato"))
        {
            vidas = vidas - 1;
            Debug.Log(vidas);
        }
    }
}
