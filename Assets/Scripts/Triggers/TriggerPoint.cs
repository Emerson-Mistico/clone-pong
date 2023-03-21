using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TriggerPoint : MonoBehaviour
{
    public Player player;
    public string tagToCheck = "Ball";

    private int _currentPlayerPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == tagToCheck)
        {
            CountPoint();
        }
    }

    private void CountPoint()
    {
        _currentPlayerPoints = player.AddPoint();
        
        if (_currentPlayerPoints >= PlayerPrefs.GetInt("pointsToWin"))
        {
            GameManager.Instance.EndGame(player.name.ToString());
        } else
        {
            GameManager.Instance.ResetBallPosition(player.name.ToString(), true);
        }        
    }

}
