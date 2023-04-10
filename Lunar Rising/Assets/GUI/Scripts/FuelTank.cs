using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTank : MonoBehaviour
{
    public Slider slider;

    public void SetMaxFuel(int fuel)
    {
        slider.maxValue = fuel;
        slider.value = fuel;
    }

    public void SetFuel(int fuel)
    {
        slider.value = fuel;
    }
}
