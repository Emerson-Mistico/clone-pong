using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeName : MonoBehaviour
{

    [Header("References")]
    public TextMeshProUGUI uiTextName;
    public TextMeshProUGUI uiHudTextName;
    public TMP_InputField uiInputFieldName;
    public Player player;

    private string playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoChangeName()
    {
        playerName = uiInputFieldName.text;
        uiTextName.text = playerName;
        uiHudTextName.text = playerName;
        player.name = playerName;
    }

    
}
