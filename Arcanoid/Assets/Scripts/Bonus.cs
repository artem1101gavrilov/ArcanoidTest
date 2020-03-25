using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Circle
{
    protected override void Start()
    {
        base.Start();
        SetDirection(0, -1);
    }

    public void SetPaddle(Paddle paddle)
    {
        this.paddle = paddle;
    }

    protected override void Colissions()
    {
        CheckBorder();
        CheckPaddle();
    }

    protected override void CheckBorder()
    {
        if (upBorder < downBorderMap)
        {
            Destroy(gameObject);
        }
    }

    protected override void CollisionPaddle(Paddle paddle)
    {
        paddle.SetBonus();
        Destroy(gameObject);
    }
}