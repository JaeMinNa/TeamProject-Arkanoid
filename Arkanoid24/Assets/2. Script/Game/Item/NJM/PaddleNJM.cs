using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleNJM : MonoBehaviour
{
    [SerializeField] GameObject _LaserPrefab;
    public bool IsLaser = false;

    void Update()
    {
        if (IsLaser == true)
        {
            // InputSystem���� �ٲ�� ��
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(_LaserPrefab, transform.position, Quaternion.identity);

                IsLaser = false;
            }
        }
    }
}
