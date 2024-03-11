using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer MySR;
    public Sprite DefaultImage;
    public Sprite PressedImage;

    public KeyCode KeyToPress;

    void Start()
    {
        MySR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyToPress))
        {
            MySR.sprite = PressedImage;
            
        }
        if (Input.GetKeyUp(KeyToPress))
        {
            MySR.sprite = DefaultImage;
        }
    }

}
