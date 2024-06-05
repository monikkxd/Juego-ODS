using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float Tempo;
    public bool StartGame;
    void Start()
    {
        Tempo = Tempo / 30f;
    }

   
    void Update()
    {
        if (!StartGame)
        {

        }
        else
        {
            transform.position -= new Vector3(0f, Tempo * Time.deltaTime, 0f);
        }
    }
}
