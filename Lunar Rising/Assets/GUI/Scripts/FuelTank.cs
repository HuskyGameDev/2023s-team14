using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTank : MonoBehaviour
{
    public Slider slider;
    public GameObject player;
    Vector3 screenToWorldPosition;
    RectTransform rectTransform;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        screenToWorldPosition = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
    }

    public void SetMaxFuel(int fuel)
    {
        slider.maxValue = fuel;
        slider.value = fuel;
    }

    public void SetFuel(int fuel)
    {
        slider.value = fuel;
    }

    public void Update()
    {
        screenToWorldPosition = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
        // if (player.transform.position)
    }
}
