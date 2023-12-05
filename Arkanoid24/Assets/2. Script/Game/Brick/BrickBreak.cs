using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickBreak : MonoBehaviour
{
    public int _hp;

    [Range(0f, 100f)]
    public int _itemCreateRate;

    public GameObject _itemSpawner;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "VersusMode")
        {
            _itemCreateRate = 0;
        }
    }
    //�浹�� �߻��ϸ� ����
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            _hp -= collision.gameObject.GetComponent<Ball>()._maxPower;
        }
        else if(collision.gameObject.tag == "Ball1" || collision.gameObject.tag == "Ball2")
        {
            _hp -= collision.gameObject.GetComponent<VersusPlayBall>()._maxPower;
        }
        //������ �浹
        else if (collision.gameObject.tag == "Bullet")
        {
            //_hp -= collision.gameObject.GetComponent<Laser>()._maxPower;
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
            BrickDestroy(collision.gameObject.tag);
        }
    }

    //�긯�� �����ϴ� �޼���
    public void BrickDestroy(string ballType)
    {
        if (ballType == "Ball" || ballType == "Bullet") 
        {
            // [�ڻ��] ���� �ı��� ���� 100�� �߰�
            // ������ ���� ���� ������ ���� ���� ����
            Managers.Game.AddScore(100);
        }
        else if(ballType =="Ball1")
        {
            Managers.Versus.Player1BrickCount();
        }
        else if(ballType == "Ball2")
        {
            Managers.Versus.Player2BrickCount();
        }

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
