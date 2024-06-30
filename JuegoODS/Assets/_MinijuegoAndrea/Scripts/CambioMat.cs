using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioMat : MonoBehaviour
{
    public GameObject plataforma;
    public Material materialVerde;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        Renderer rend = plataforma.GetComponent<Renderer>();
        if (collider.tag == "AGUA")
        {
            rend.material = materialVerde;
            Debug.Log("TOCADO " + collider.gameObject.name);
        }
    }
}
