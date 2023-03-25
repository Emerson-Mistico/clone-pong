using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // SoundManager to singleton
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;

    private void Awake()
    {
        #region Singleton SoundManager
        Instance = this;
        #endregion
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