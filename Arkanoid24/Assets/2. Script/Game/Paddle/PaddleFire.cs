
using System;
using UnityEngine;

public class PaddleFire : MonoBehaviour
{
    private PaddleController _paddleController;

    private void Start()
    {
        _paddleController = GetComponent<PaddleController>();

        // �̺�Ʈ ���
        _paddleController.OnFireEvent += OnBallFire;
    }

    private void OnBallFire()
    {
        foreach(var ball in Managers.Game.CurrentBalls)
        {
            ball.GetComponent<Ball>().CallBallLaunch();
        }
    }

    private void OnDisable()
    {
        _paddleController.OnFireEvent -= OnBallFire;
    }
}