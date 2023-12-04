using UnityEngine;

public partial class ArkanoidBall : MonoBehaviour
{
    [SerializeField] private GameManager game;

    [Header("Speed")]
    [SerializeField] public float ballMaxSpeed;

    private Rigidbody2D paddleBody;
    private Rigidbody2D ballBody;



    public bool isLaunch = false;
    private bool isCatch = false;

    private int _defaultPower = 1;
    private int _maxPower = 1;
    private float _posX;


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
        paddleBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // �ν��Ͻ� ���� ����
        Managers.Event.OnBallLaunch += StartBall;
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
        Managers.Event.PublishBallIsLaunch(isLaunch);
    }

    private void ReadyBall()
    {
        FollowThePaddle();
    }

    private void FollowThePaddle()
    {
        Vector2 paddlePos = paddleBody.position;
        Vector2 newBallPos = new Vector2(paddlePos.x, ballBody.position.y);
        ballBody.position = newBallPos;
        ballBody.velocity = Vector2.zero;
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
        if (Managers.Instance != null && Managers.Event != null)
        {
            Managers.Event.PublishBallIsLaunch(false);
            Managers.Event.OnBallLaunch -= StartBall;
        }
    }
}
