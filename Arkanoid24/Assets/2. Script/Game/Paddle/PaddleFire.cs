
using UnityEngine;

public class PaddleFire : MonoBehaviour
{
    private void Start()
    {
        // ��Ŭ�� �̺�Ʈ ���
        Managers.Event.OnFireEvent += OnBallFire;
    }

    private void OnBallFire()
    {
        // ���� �ִ� ���� �����´�.
        var remainBall = Managers.Game.CurrentBalls.Find(ball => ball != null).GetComponent<Ball>();

        if (remainBall.BallState != BallPreference.BALL_STATE.READY) return;

        Managers.Event.PublishBallLaunch();
    }
}