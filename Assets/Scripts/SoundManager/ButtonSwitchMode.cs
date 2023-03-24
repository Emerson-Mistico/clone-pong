using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitchMode : MonoBehaviour
{
    
    [Header("Buton Settings")]
    public Sprite imagetoShowOn;
    public Sprite imageToShowOff;

    public Image imageToShow;

    private void Awake()
    {
        imageToShow.sprite = imagetoShowOn;
    }

    public void SwitchImage()
    {
        if (imageToShow.sprite == imagetoShowOn) { 
            imageToShow.sprite = imageToShowOff;
        }
        else
        {
            imageToShow.sprite = imagetoShowOn;
        }
    }
    
}
