
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    #region STATE
    public enum PADDLE_STATE
    {
        READY,
        MOVEMENT
    }
    #endregion



    #region Member Variables

    public const string SoloMaps = "SoloPaddle";
    public const string MultiMaps = "MultiPaddle";

    // Input Field
    protected PlayerInput _playerInput;

    // Physics
    protected Rigidbody2D _rbody;
    protected float _paddleSpeed = 10f;

    // Camera
    [SerializeField] protected Camera _paddleCamera;

    #endregion



    #region Properties
    public PADDLE_STATE PaddleState {  get; set; } = PADDLE_STATE.READY;
    #endregion



    #region Unity Flow
    private void Awake()
    {
        // Get Component
        _playerInput = GetComponent<PlayerInput>();
        _rbody = GetComponent<Rigidbody2D>();

        // Service Register
        ServiceLocator.RegisterService(this);
    }

    private void OnEnable()
    {
        Action enableAction = (isMulti == true) ? EnableMultiPaddle : EnableSoloPaddle;

        
        EnableMultiPaddle();
    }
    #endregion


    #region Swtich Action Maps
    public void EnableSoloPaddle()
    {
        _playerInput.SwitchCurrentActionMap(SoloMaps);
    }

    public void EnableMultiPaddle()
    {
        _playerInput.SwitchCurrentActionMap(MultiMaps);
    }
    #endregion


    #region TES
    public bool isMulti = true;

    private void FixedUpdate()
    {
        if (isMulti)
        {
            ProcessMultiplayerInput();
        }
        else
        {
            //ProcessSingleplayerInput();
        }
    }

    private void ProcessMultiplayerInput()
    {
        // ��Ƽ�÷��̾� ��忡�� �÷��̾� 1�� �Է��� �н��ϴ�.
        Vector2 player1Input = _playerInput.actions["Movement"].ReadValue<Vector2>();
        // �÷��̾� 1�� Rigidbody2D�� �̵���ŵ�ϴ�.
        // �� �������� x�� �������θ� �̵��Ѵٰ� �����մϴ�.
        MovePaddle(_rbody, player1Input.x);

        // ��Ƽ�÷��̾� ��忡�� �÷��̾� 2�� �Է��� �н��ϴ�.
        Vector2 player2Input = _playerInput.actions["Movement"].ReadValue<Vector2>();
        // �÷��̾� 2�� Rigidbody2D�� �̵���ŵ�ϴ�.
        // �÷��̾� 2�� Rigidbody2D�� ������ �����ؾ� �� ���� �ֽ��ϴ�.
        // MovePaddle(player2Rigidbody, player2Input.x);

        Debug.Log("Multiplayer Input Player 1: " + player1Input);
        Debug.Log("Multiplayer Input Player 2: " + player2Input);
    }

    private void ProcessSingleplayerInput()
    {
        // �̱� �÷��̾� ��忡�� ���콺�� ��ġ�� �н��ϴ�.
        Vector2 mouseInput = _playerInput.actions["MousePosition"].ReadValue<Vector2>();
        // ���콺 ��ġ�� ���� Rigidbody2D�� �̵���ŵ�ϴ�.
        MovePaddleWithMouse(mouseInput);

        Debug.Log("Singleplayer Mouse Input: " + mouseInput);
    }

    private void MovePaddle(Rigidbody2D rbody, float inputX)
    {
        // Rigidbody2D�� �̵���Ű�� ������ �����մϴ�.
        rbody.velocity = new Vector2(inputX * _paddleSpeed, rbody.velocity.y);
    }

    private void MovePaddleWithMouse(Vector2 mousePosition)
    {
        // ���콺 ��ġ�� ���� Rigidbody2D�� �̵���Ű�� ������ �����մϴ�.
        // ���콺 �����͸� ���� ��ǥ�� ��ȯ�� �ʿ䰡 �ֽ��ϴ�.
        Vector2 worldPosition = _paddleCamera.ScreenToWorldPoint(mousePosition);
        _rbody.position = new Vector2(worldPosition.x, _rbody.position.y);
    }
    #endregion
}