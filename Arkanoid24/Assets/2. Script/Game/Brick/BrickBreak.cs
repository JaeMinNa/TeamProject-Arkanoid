using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    public int _hp;

    [Range(0f, 100f)]
    public int _itemCreateRate;

    public GameObject _itemSpawner;
    //�浹�� �߻��ϸ� ����
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            _hp--;
        }
        if (_hp <= 0)
        {
            BrickDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _hp -= collision.gameObject.GetComponent<Laser>()._power;
        }
        if (_hp <= 0)
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
    public void instantiateItem()
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
