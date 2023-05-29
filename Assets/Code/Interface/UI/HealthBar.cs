using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public HealthController healthController;

    void Start()
    {
        SetMaxHealth();
    }

    void Update()
    {
        SetHealth();
    }

    public void SetMaxHealth()
    {
        slider.maxValue = healthController.maximumHealth;
        slider.value = healthController.maximumHealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth()
    {
        float currentHealth = healthController.currentHealth;
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
