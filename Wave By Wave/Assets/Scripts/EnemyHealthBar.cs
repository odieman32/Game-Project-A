using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera Camera;
    [SerializeField] private Transform target;

    public void UpdateHealthBar(float currentValue, float maxValue) //updates the healthbar and take the current value divided by max value of the slider
    {
        slider.value = currentValue/maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //lets camera rotate with camera
        transform.rotation = Camera.transform.rotation;
        //stays on enemy position
        target.position = target.position;
    }
}
