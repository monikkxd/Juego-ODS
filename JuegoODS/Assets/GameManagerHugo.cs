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

    private void Update()
    {
        if (activador.gameObject.activeSelf)
        {
            StartCoroutine(IncreaseWeight());
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
}