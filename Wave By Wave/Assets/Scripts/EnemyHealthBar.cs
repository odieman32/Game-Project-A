using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    //Fields doe the camera, target and the health bar slider
    [SerializeField] private Slider slider;
    [SerializeField] private Camera Camera;
    [SerializeField] private Transform target;

    public void UpdateHealthBar(float currentValue, float maxValue) //updates the healthbar and take the current value divided by max value of the slider
    {
        slider.value = currentValue/maxValue;
    }
    void Update()
    {
        //lets camera rotate with camera
        transform.rotation = Camera.transform.rotation;
        //stays on enemy position
        target.position = target.position;
    }
}
