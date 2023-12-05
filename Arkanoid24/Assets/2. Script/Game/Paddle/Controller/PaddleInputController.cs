
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleInputController : PaddleController
{
    #region Member Variables

    private Camera _mainCamera;

    #endregion


    #region Unity Flow
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();

        // Data Caching
        _mainCamera = Camera.main;
    }
    #endregion


    #region Event Methods

    private void OnMovement(InputValue inputValue)
    {
        if (Managers.Game.State == GameState.Pause) return;

        Vector2 mousePos = inputValue.Get<Vector2>();

        // ���콺 ��ġ�� ����
        mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
        mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);

        // ���� ��ǥ�� ��ȯ
        mousePos = _mainCamera.ScreenToWorldPoint(mousePos);

        Managers.Event.PublishMoveEvent(mousePos);
    }

    private void OnFire(InputValue inputValue)
    {
        Managers.Event.PublishFireEvent();
    }

    #endregion
}