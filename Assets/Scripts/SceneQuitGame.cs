using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneQuitGame : MonoBehaviour
{
    private void Awake()
    {
        Invoke("QuitGame", 3f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
