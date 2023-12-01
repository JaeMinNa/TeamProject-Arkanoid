
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleInputController : MonoBehaviour
{
    #region Member Variables

    private Camera _mainCamera;

    #endregion


    #region Unity Flow
    private void Start()
    {
        // Data Caching
        _mainCamera = Camera.main;
    }
    #endregion


    #region Event Methods

    private void OnMovement(InputValue inputValue)
    {
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