using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    [Header("Player Settings")]
    public float playerSpeed = 1.5f;
    public Image uiPlayer;

    public Rigidbody2D myRigidbody2D;

    [Header("Key Setup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keycodeMoveDown = KeyCode.DownArrow;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI hudPointsToShow;

    private void Awake()
    {
        ResetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyCodeMoveUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * playerSpeed);
        }
        else if (Input.GetKey(keycodeMoveDown))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * playerSpeed * -1);
        }
    }

    public int AddPoint()
    {
        currentPoints++;
        hudPointsToShow.text = currentPoints.ToString();

        return currentPoints;
    }

    public void ChangeColor(Color colorToChange)
    {
        uiPlayer.color = colorToChange;
    }

    private void ResetPlayer()
    {
        currentPoints = 0;
        hudPointsToShow.text = currentPoints.ToString();
    }
}
