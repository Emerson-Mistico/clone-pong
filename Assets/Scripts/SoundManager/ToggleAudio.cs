using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic, _toggleEffetcs;

    public void Toggle()
    {
        if (_toggleEffetcs)
        {
            SoundManager.Instance.ToggleEffects();
        }

        if (_toggleMusic) { 
            SoundManager.Instance.ToggleMusic();
        }

    }


}
