using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent (typeof(Image))]

public class ButtonColorBase : MonoBehaviour
{
    public Color colorToChange;

    [Header ("References")]
    public Image uiImage;
    public Player myPlayer;
    public TextMeshProUGUI uiPlayerName;

    public void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    void Start()
    {
        uiImage.color = colorToChange;
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(colorToChange);
        uiPlayerName.color = colorToChange;
    }
}
