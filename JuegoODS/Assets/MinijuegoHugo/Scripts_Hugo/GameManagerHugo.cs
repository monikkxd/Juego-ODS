using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManagerHugo : MonoBehaviour
{
    [SerializeField] private Volume greenFilter;
    [SerializeField] private Volume greyFilter;

    public GameObject activador;

    public GameObject SueloVerde;
    public GameObject SueloGris;

    public GameObject Vegetación;

    public GameObject tuto;

    public Animator animator_1;
    public Animator animator_2;
    public Animator animator_3;
    public Animator animator_4;

    public GameObject escenarioSucio;



    private void Start()
    {
        Invoke("ActivarTuto", 2f);
        Invoke("DesactivarTuto", 6f);
    }
    private void Update()
    {
        if (activador.gameObject.activeSelf)
        {
            StartCoroutine(IncreaseWeight());

            SueloVerde.SetActive(true);
            SueloGris.SetActive(false);
            escenarioSucio.SetActive(false);
            Vegetación.SetActive(true);

            animator_1.enabled = true;
            animator_2.enabled = true;
            animator_3.enabled = true;
            animator_4.enabled = true;


        }
    }

    private IEnumerator IncreaseWeight()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 3f)
        {
            elapsedTime += Time.deltaTime;
            greenFilter.weight = Mathf.Lerp(0f, 0.75f, elapsedTime / 3f);
            greyFilter.weight = Mathf.Lerp(0.75f, 0f, elapsedTime / 3f);
            yield return null;
        }
        StartCoroutine(DecreaseWeight());
    }

    private IEnumerator DecreaseWeight()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 3f)
        {
            elapsedTime += Time.deltaTime;
            greenFilter.weight = Mathf.Lerp(0.75f, 0.75f, elapsedTime / 3f);
            greyFilter.weight = Mathf.Lerp(0f, 0f, elapsedTime / 3f);
            yield return null;
        }
        greenFilter.weight = 0.75f;
        greyFilter.weight = 0f;
    }

    void ActivarTuto()
    {
        tuto.SetActive(true);
    }

    void DesactivarTuto()
    {
        tuto.SetActive(false);
    }
}