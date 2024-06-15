using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niebla : MonoBehaviour
{
    public Material myMaterial;

    [Range(0f,1f)]
    public float alpha = 0.7f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alpha = alpha - 0.00005f;
        myMaterial.color = new Color(myMaterial.color.r, myMaterial.color.g, myMaterial.color.b, alpha);
    }
}
