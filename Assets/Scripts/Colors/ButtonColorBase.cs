using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]

public class ButtonColorBase : MonoBehaviour
{
    public Color colorToChange;

    [Header ("References")]
    public Image uiImage;

    public void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    void Start()
    {
        uiImage.color = colorToChange;
    }
}
