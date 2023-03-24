using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // SoundManager to singleton
    public static SoundManager Instance;

    [Header("Background Sounds")]
    public GameObject trackBackground1;

    [Header("Sound Effects")]
    public GameObject effectBallCollision;

    private void Awake()
    {
        #region Singleton SoundManager
        // Enforce unique instance of this class
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
}
