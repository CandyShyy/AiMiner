using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MineralsBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public ACMining acMining;
    public TextMeshProUGUI harvestedmineralsText;

    void Start()
    {
        SetMaxMinerals(acMining.maxCargo);
    }

    public void SetMaxMinerals(int minerals)
    {
        slider.maxValue = minerals;
        slider.value = 0;

        fill.color = gradient.Evaluate(0f);
    }

    public void SetMinerals(int minerals)
    {
        slider.value = minerals;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
        SetMinerals(acMining.totalMineralsHarvested);
        harvestedmineralsText.text = acMining.totalMineralsHarvested.ToString();
    }
}
