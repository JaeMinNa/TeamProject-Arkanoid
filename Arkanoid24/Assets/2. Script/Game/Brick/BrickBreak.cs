using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    [SerializeField] int _hp;

    [Range(0f, 100f)]
    [SerializeField] int _itemCreateRate;

    public GameObject _itemSpawner;
    //�浹�� �߻��ϸ� ����
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            _hp--;
            Debug.Log($"���� ü�� {_hp}");
        }
        if(_hp <= 0)
        {
            BrickDestroy();
        }
    }

    //�긯�� �����ϴ� �޼���
    public void BrickDestroy()
    {
        // [�ڻ��] ���� �ı��� ���� 100�� �߰�
        // ������ ���� ���� ������ ���� ���� ����
        Managers.Game.AddScore(100);

        instantiateItem();
        Destroy(gameObject);
    }

    //������ ���� ����
    private void instantiateItem()
    {
        //_itemCreateRate ������ ��� ������ ����
        if (Random.Range(0, 101) <= _itemCreateRate)
        {
            _itemSpawner.transform.position = transform.position;
            Instantiate(_itemSpawner);
            _itemSpawner.transform.position = Vector2.zero;
        }
    }
}
