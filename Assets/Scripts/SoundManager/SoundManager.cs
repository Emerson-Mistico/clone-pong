using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // SoundManager to singleton
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;
    public Slider _volumeSlider;

    private void Awake()
    {
        #region Singleton SoundManager
        Instance = this;
        #endregion

        ChangeMasterVolume(_volumeSlider.value);
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
       
    }

    public void ChangeMasterVolume(float sliderValue)
    {
        AudioListener.volume = sliderValue;
    }

    public void ToggleEffects()
    {
        _effectsSource.mute = !_effectsSource.mute;
    }

    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }

}
