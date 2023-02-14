using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUpdater : MonoBehaviour
{
    public ACMining acMining;
    public Slider slider;
    public ParticleSystem particles;
    public Text mineralsText;
    public float fillSpeed = 1f;

    private float targetValue;
    private float currentValue;

    private void Update()
    {
        targetValue = (float)acMining.totalMineralsHarvested;
        currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * fillSpeed);
        slider.value = currentValue;

        mineralsText.text = acMining.totalMineralsHarvested.ToString();
    }
}
