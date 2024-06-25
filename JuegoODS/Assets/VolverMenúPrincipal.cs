using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenúPrincipal : MonoBehaviour
{
    public GameObject transición;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Secuencia());
        }
    }
    public IEnumerator Secuencia()
    {
        transición.SetActive(true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("MenuPrincipal");
    }


}
