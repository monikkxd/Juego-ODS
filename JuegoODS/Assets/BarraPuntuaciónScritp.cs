using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraPuntuaciónScritp : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValueSlider(int  Value)
    {
        slider.maxValue = Value;
        slider.value = Value;
    }

    public void SetValue(int Value)
    {
        slider.value = Value;
    }
}
