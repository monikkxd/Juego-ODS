using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform carrilesParent;
    public Transform[] carrilesPositions;

    public Transform carrilPositionActual;

    public int carrilActualIndex = 1; //carriles 0, 1 y 2

    public float playerHorizontalSpeed=10f;


    // Start is called before the first frame update
    void Start()
    {
        carrilesPositions = new Transform[carrilesParent.childCount];
        for (int i = 0; i < carrilesParent.childCount; i++)
        {
            carrilesPositions[i] = carrilesParent.GetChild(i);
        }

        carrilPositionActual = carrilesPositions[carrilActualIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (carrilActualIndex > 0)
            {
                carrilActualIndex--;            
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (carrilActualIndex < carrilesPositions.Length-1)
            {
                carrilActualIndex++;
            }
        }
        carrilPositionActual = carrilesPositions[carrilActualIndex];

        transform.position = Vector3.MoveTowards(transform.position,carrilPositionActual.position,playerHorizontalSpeed*Time.deltaTime);

    }

}
