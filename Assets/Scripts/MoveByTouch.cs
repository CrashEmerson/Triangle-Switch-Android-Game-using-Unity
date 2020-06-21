using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody2D ball;
    public Joystick Joystick;
    private float _horizontalMove, _verticalMove;
    public float MoveSpeed = 20f;
    
    void Update()
    {
        _horizontalMove = Joystick.Horizontal;
        _verticalMove = Joystick.Vertical;
        if(ball != null)
        {
            ball.velocity = new Vector2(_horizontalMove * MoveSpeed, _verticalMove * MoveSpeed);
        }
    }
    public void IncreaseBallSpeed()
    {
        MoveSpeed = MoveSpeed + 0.5f;
    }
}