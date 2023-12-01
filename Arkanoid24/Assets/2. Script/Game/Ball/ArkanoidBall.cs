using UnityEngine;

public class ArkanoidBall : MonoBehaviour
{
    [SerializeField] private ArkanoidGame game;

    [Header("Speed")]
    [SerializeField] public float ballMaxSpeed;

    private Rigidbody2D ballBody;
    private bool isLaunch = false;
    private PaddleFire paddleFire;

    /// <summary>
    /// Ball �ӵ� ���� [�ӽ�]
    /// </summary>
    /// <param name="speed"></param>
    public void SetMaxSpeed(float speed)
    {
        ballMaxSpeed = speed;
    }

    private void Awake()
    {
        ballBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // �ν��Ͻ� ���� ����
        paddleFire = Managers.Game.Paddle;
        paddleFire.OnBallFireRequest += StartBall;
    }

    private void FixedUpdate()
    {
        if (!isLaunch)
        {
            ReadyBall();
        }
        else
        {
            LaunchBall();
        }
    }

    #region Ball State

    public void StartBall()
    {
        isLaunch = true;
        ballBody.velocity = new Vector2(0, 10);
    }

    private void ReadyBall()
    {
        transform.position = paddleFire.transform.position;
    }

    private void LaunchBall()
    {
        if (ballBody.velocity.magnitude > ballMaxSpeed)
        {
            ballBody.velocity = ballBody.velocity.normalized * ballMaxSpeed;
        }
    }

    #endregion

    #region Ball Collision

    /// <summary>
    /// ���� �е��� x��ǥ�� ���� �ܰ� ���� ũ�� �ο�
    /// </summary>
    /// <param name="paddlePos">�е� ������</param>
    /// <param name="paddleWidth">�е� �ݶ��̴� �ʺ�</param>
    /// <returns>���� X��ġ �� ��ŭ ���� x�� �ο�</returns>
    private float HitFactor(Vector2 paddlePos, float paddleWidth)
    {
        return (transform.position.x - paddlePos.x) / paddleWidth * 2f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var x = HitFactor(col.transform.position, col.collider.bounds.size.x);
            var dir = new Vector2(x, 1).normalized;
            ballBody.velocity = dir * ballMaxSpeed;
        }
    }

    #endregion

    private void OnDestroy()
    {
        paddleFire.OnBallFireRequest -= StartBall;
    }
}
