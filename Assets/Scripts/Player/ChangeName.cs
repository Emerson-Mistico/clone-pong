using UnityEngine;
using TMPro;

public class ChangeName : MonoBehaviour
{

    [Header("References")]
    public TextMeshProUGUI uiTextName;
    public TextMeshProUGUI uiHudTextName;
    public TextMeshProUGUI instructionsPlayerName;

    public TMP_InputField uiInputFieldName;
    public Player player;

    private string playerName;

    private void Awake()
    {
        uiTextName.text = player.name;
    }

    public void DoChangeName()
    {        
        playerName = uiInputFieldName.text;
        uiTextName.text = playerName;
        uiHudTextName.text = playerName;
        player.name = playerName;
        instructionsPlayerName.text = playerName;

        if (player.tag == "Player1")
        {
            PlayerPrefs.SetString("namePlayer1", playerName);
        } else if (player.tag == "Player2") {
            PlayerPrefs.SetString("namePlayer2", playerName);
        }

    }

    
}
