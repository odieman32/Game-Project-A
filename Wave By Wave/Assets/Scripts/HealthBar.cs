using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; //field to put health bar in

    public void SetSlider(float amount)
    {
        healthSlider.value = amount; //health bar slider value is connected to amount
    }

    public void SetSLiderMax(float amount)
    {
        healthSlider.maxValue = amount;//The health bar max value is connected to amount
        SetSlider(amount); //slider moves when amount changes
    }
}

