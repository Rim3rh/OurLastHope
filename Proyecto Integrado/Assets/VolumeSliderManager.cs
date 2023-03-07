using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderManager : MonoBehaviour
{
    public Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider.value = GameManager.Instance.musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.musicVolume = _slider.value;
    }
}
