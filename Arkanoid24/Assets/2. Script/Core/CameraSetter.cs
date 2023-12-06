
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    private Canvas _mainUI;

    private void Awake()
    {
        _mainUI = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        InitCanvasCamera();
    }

    private void InitCanvasCamera()
    {
        if (_mainUI == null) throw new System.Exception("Canvas�� �������� �ʽ��ϴ�.");

        _mainUI.worldCamera = gameObject.GetComponent<Camera>();
    }
}
