using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    [SerializeField] int _hp;

    [Range(0f, 100f)]
    [SerializeField] int _itemCreateRate;

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
    private void BrickDestroy()
    {
        instantiateItem();
        Destroy(gameObject);
    }

    //������ ���� ����
    private void instantiateItem()
    {
        //_itemCreateRate ������ ��� ������ ����
        if (Random.Range(0, 101) <= _itemCreateRate)
        {
            //���� ��ī���̵� �������� 7���ϱ� enum�� ����� 0 ~ 7 ����
            Debug.Log(Random.Range(0, 8));
        }
    }
}
