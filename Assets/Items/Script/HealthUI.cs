using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider health3DSlider;
    public Slider health2DSlider;
    public void Start3DSlider(float maxValue)
    {
        health3DSlider.maxValue = maxValue;
        health3DSlider.value = maxValue;
    }

    public void Update3DSlider(float value)
    {
        health3DSlider.value = value;
    }

    public void Update2DSlider(float maxValue, float value)
    {
        if (gameObject.CompareTag("Player"))
        {
            health2DSlider.maxValue = maxValue;
            health2DSlider.value = value;
        }
    }
}