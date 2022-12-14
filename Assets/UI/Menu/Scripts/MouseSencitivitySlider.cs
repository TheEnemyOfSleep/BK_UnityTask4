using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSencitivitySlider : MonoBehaviour
{
    [SerializeField] private Slider _sencitiveSlider;

    public Slider SencitiveSlider
    {
        get => _sencitiveSlider;
        set => _sencitiveSlider = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _sencitiveSlider.value = ApplicationModel.MouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
