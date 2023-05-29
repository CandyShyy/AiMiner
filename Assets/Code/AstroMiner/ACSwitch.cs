using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACSwitch : MonoBehaviour
{
    public ACMining acMiningScript;
    public ACShooting acShootingScript;

    // Start is called before the first frame update
    void Start()
    {
        acShootingScript.enabled = false;
        acMiningScript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleAC();
        }
    }

    void ToggleAC()
    {
        if (acMiningScript.enabled)
        {
            acMiningScript.enabled = false;
            acShootingScript.enabled = true;
        }
        else if (acShootingScript.enabled)
        {
            acShootingScript.enabled = false;
            acMiningScript.enabled = true;
        }

        Debug.Log("ACMining enabled: " + acMiningScript.enabled);
        Debug.Log("ACShooting enabled: " + acShootingScript.enabled);
    }
}