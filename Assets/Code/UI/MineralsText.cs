using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MineralsText : MonoBehaviour
{
    public TextMeshProUGUI mineralsText;
    public ACMinerals acMinerals;

    private void Update() 
    {
        mineralsText.text = acMinerals.Minerals.ToString();
    }
   
}
