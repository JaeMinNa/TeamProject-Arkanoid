using System.Collections;
using UnityEngine;

 public class Item : MonoBehaviour
{
    private float _dropSpeed = 3f;
    private Rigidbody2D _rb;
    public float GetSpeed => (_dropSpeed);

    [SerializeField] private Items itemType;
    [SerializeField] private GameObject sprite;
    [SerializeField] private ParticleSystem particle;

    private ModelState state = ModelState.Live;
    //private Ball _mainBall;
    //private float _originSpeed;
    //private GameObject _firstBall;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (transform.position.y < -6) Destroy(gameObject);
        if (Managers.Game.State != GameState.Play)
        {
            _rb.velocity = Vector3.zero;
            return;
        }

        _rb.velocity = _dropSpeed * Vector3.down;
        //transform.position += new Vector3(0, -_dropSpeed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Managers.Skill.Player = collision.gameObject;
        
        if (collision.CompareTag("Player") && state != ModelState.Dead)
        {
            state = ModelState.Dead;
            SFX.Instance.PlayOneShot(SFX.Instance.itemPickup);
            ItemSkill(collision.gameObject);
            StartCoroutine(DeathCoroutine());
        }
    }

    private IEnumerator DeathCoroutine()
    {
        sprite.SetActive(false);
        particle.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void ItemSkill(GameObject player)
    {
        switch (itemType)
        {
            case Items.Player:
                // ��� �߰�
                Managers.Skill.PlayerItem();
                break;

            case Items.Lasers:
                // 2�߾� �߻�
                Managers.Skill.Lasers(player);
                break;

            case Items.Enlarge:
                // �е��� 1.5�� Ŀ��(����)
                Managers.Skill.Enalarge(player);
                break;

            case Items.Catch:
                // ���� ƨ�����ʰ� �е鿡 �޶����
                Managers.Skill.Catch();
                break;

            case Items.Slow:
                // �� �ӵ� ����
                Managers.Skill.Slow(player);
                break;

            case Items.Disruption:
                // �� 2�� �߰�
                Managers.Skill.Disruption(player);
                break;

            case Items.Power:
                Managers.Skill.PowerUp(player);
            break;

        }
    }

}