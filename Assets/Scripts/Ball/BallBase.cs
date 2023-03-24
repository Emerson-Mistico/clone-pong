using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [Header("Ball Settings")]
    public Vector3 ballSpeed = new Vector3(0.15f, 0.15f);
    public float timetoSetBallFree = 0.55f;

    [Header("Ball Random Settings")]
    public Vector2 randSpeedY = new Vector2(-0.25f, 0.7f);
    public Vector2 randSpeedX = new Vector2(0.15f, 1.3f);

    [Header("Ball Colision Setiings")]
    public Player playerToCheck;
    public string keyToCheck = "Player";
    public string wayToCheck = "Player 1";

    private Vector3 _startPosition;
    private Vector3 _startBallSpeed;
    private bool _ballCanMove = false;

    private void Awake()
    {
        _startPosition = transform.position;
        _startBallSpeed = ballSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (_ballCanMove)
        {
            transform.Translate(ballSpeed);
            wayToCheck = playerToCheck.name;
        } else
        {
            return;
        }
    }

    #region Ball Movment Manipulation
    public void ballCanMove(bool state)
    {
        _ballCanMove = state;
    }

    public void ResetBall(string currentWay, bool moveBall)
    {
        ballCanMove(false);
        ballSpeed = _startBallSpeed;

        // Check who made the point for the advantage and direction of the initial shot of the ball
        if (currentWay != wayToCheck)
        {
            ballSpeed.x *= -1;
        }
        transform.position = _startPosition;
        if (moveBall)
        {
            Invoke(nameof(SetBallFree), timetoSetBallFree);
        }
    }

    private void SetBallFree()
    {              
        ballCanMove(true);
    }
    #endregion

    #region Collision Manipulation
    // Checks if the collision is with a player to reverse the direction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == keyToCheck)
        {
            OnPlayerCollision();
        } else
        {
            ballSpeed.y *= -1;
        }
    }

    // Randomly changes the speed of the ball (within an established range)
    private void OnPlayerCollision()
    {
        ballSpeed.x *= -1;
        float rand = Random.Range(randSpeedX.x, randSpeedY.y);

        if (ballSpeed.x < 0)
        {
            rand *= -1;
        } else
        {
            ballSpeed.x = rand;
        }
    }
    #endregion

}
