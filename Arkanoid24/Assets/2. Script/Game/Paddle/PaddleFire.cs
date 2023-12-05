
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
        // ���� �ִ� ���� �����´�.
        var remainBall = Managers.Game.CurrentBalls.Find(ball => ball != null).GetComponent<Ball>();

        if (remainBall.BallState != BallPreference.BALL_STATE.READY) return;

        Managers.Event.PublishBallLaunch();
    }

    private void OnDisable()
    {
        _paddleController.OnFireEvent -= OnBallFire;
    }
}