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

    public GameObject spawner1, spawner2, spawner3;

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
        if (vidas <= 0)
        {
            VidaBn1.SetActive(false);
            VidaMal1.SetActive(true);
            VidaBn2.SetActive(false);
            VidaMal2.SetActive(true);
            VidaBn3.SetActive(false);
            VidaMal3.SetActive(true);
            VidaBn4.SetActive(false);
            VidaMal4.SetActive(true);

            spawner1.SetActive(false );
            spawner2.SetActive(false );
            spawner3.SetActive(false );

            //Time.timeScale = 0;
            hasPerdido.SetActive(true);
            raton.SetActive(true);
            StartCoroutine(CargarEscenaAlPerder());
            Debug.Log("CargoEscena");
           
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

   IEnumerator CargarEscenaAlPerder()
   {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("SelecciónNivel");
   }
}
