using UnityEngine;
using TMPro;

public class EndGameMenu : MonoBehaviour
{

    [Header("References")]
    public TextMeshProUGUI uiWinnerText;

    // Start is called before the first frame update
    void Start()
    {
        uiWinnerText.text = PlayerPrefs.GetString("lastWinner");
    }
    
}
