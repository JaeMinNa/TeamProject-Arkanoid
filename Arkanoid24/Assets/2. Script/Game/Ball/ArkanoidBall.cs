using UnityEngine;

public class ArkanoidBall : MonoBehaviour
{
    [SerializeField] private GameManager game;

    [Header("Speed")]
    [SerializeField] public float ballMaxSpeed;

    private Rigidbody2D paddleBody;
    private Rigidbody2D ballBody;

    private bool isLaunch = false;
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
        if (Managers.Game.State == GameState.Pause)
        {
            ballBody.velocity = Vector3.zero;
            return;
        }

        if (!isLaunch || isCatch)
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
        if(isCatch) FollowThePaddle(_posX);
        else FollowThePaddle();
    }

    private void FollowThePaddle(float posX = 0f)
    {
        Vector2 paddlePos = paddleBody.position;
        Vector2 newBallPos = new Vector2(paddlePos.x, ballBody.position.y);
        ballBody.position = newBallPos + new Vector2(posX, 0);
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
            CheckCatchActivation();
            if (!isCatch)
            {
                var x = HitFactor(col.transform.position, col.collider.bounds.size.x);
                var dir = new Vector2(x, 1).normalized;
                ballBody.velocity = dir * ballMaxSpeed;
            }
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
    #region Item SKill

    private void CheckCatchActivation()
    {
        if (Managers.Skill.CurrentSkill == Items.Catch)
        {
            isCatch = true;
            _posX = transform.position.x - paddleBody.transform.position.x;
        }
        else
        {
            isCatch = false;
        }

    }

    public void CatchBall()
    {
        //var ballPos = transform.position - paddleFire.transform.position;
        //transform.position = paddleFire.transform.position + new Vector3(0f, 0.5f, 0f);
        //ballBody.velocity = Vector3.zero;
    }

    public void SetPower(int extraPower)
    {
        _maxPower = _defaultPower + extraPower;
    }

    #endregion
}
