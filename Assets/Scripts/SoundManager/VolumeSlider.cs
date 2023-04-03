using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    [SerializeField] private Slider _sliderVolume;



    void Start()
    {
        SoundManager.Instance.ChangeMasterVolume(_sliderVolume.value);
        _sliderVolume.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
    }
    
}
