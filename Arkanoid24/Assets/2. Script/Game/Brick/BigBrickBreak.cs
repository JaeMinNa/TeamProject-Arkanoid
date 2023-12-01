using UnityEngine;

public class BigBrickBreak : MonoBehaviour
{
    [SerializeField] int _hp;

    [Range(0f, 100f)]
    [SerializeField] int _itemCreateRate;

    public GameObject _itemSpawner;

    public Sprite _phaseHealthSprite1;
    public Sprite _phaseHealthSprite2;
    public Sprite _phaseHealthSprite3;
    public Sprite _phaseHealthSprite4;
    public Sprite _phaseHealthSprite5;

    //�浹�� �߻��ϸ� ����
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            _hp--;
            Debug.Log($"���� ü�� {_hp}");
        }
        PhaseSpriteSetting();
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
    private void instantiateItem()
    {
        //_itemCreateRate ������ ��� ������ ����
        if (Random.Range(0, 101) <= _itemCreateRate)
        {
            _itemSpawner.transform.position = transform.position;
            Instantiate(_itemSpawner);
        }
    }

    private void PhaseSpriteSetting()
    {
        switch (_hp)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = _phaseHealthSprite5;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = _phaseHealthSprite4;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = _phaseHealthSprite3;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = _phaseHealthSprite2;
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = _phaseHealthSprite1;
                break;

        }
    }
}
