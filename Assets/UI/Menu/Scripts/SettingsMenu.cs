using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider _sencitiveSlider;

    public Slider SencitiveSlider
    {
        get => _sencitiveSlider;
        set => _sencitiveSlider = value;
    }

    public void ApplySettings()
    {
        ApplicationModel.MouseSensitivity = _sencitiveSlider.value;
    }
}
