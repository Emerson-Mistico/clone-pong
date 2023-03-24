using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWelcome : MonoBehaviour
{
 
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("SCN_Pong");
        }
    }
}
