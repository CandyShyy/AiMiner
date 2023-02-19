using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    private Toggle[] toggles;

    private void Start()
    {
        toggles = GetComponentsInChildren<Toggle>();

        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
    }

    private void OnToggleValueChanged(bool value)
    {
        if (!value)
        {
            return;
        }

        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn && toggle != this)
            {
                toggle.isOn = false;
            }
        }
    }
}
