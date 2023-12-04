using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

 public partial class Item : MonoBehaviour
{
    private float _dropSpeed = 3f;
    private Rigidbody2D _rb;

    public float GetSpeed => (_dropSpeed);

    [SerializeField] private Items itemType;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject balls;
    private ArkanoidBall _mainBall;
    private float _originSpeed;
    private GameObject _firstBall;



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = _dropSpeed * Vector3.down;
        //transform.position += new Vector3(0, -_dropSpeed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemSkill(collision.gameObject);

            //Destroy(gameObject);
        }
    }

    private void ItemSkill(GameObject player)
    {
        switch (itemType)
        {
            case Items.Player:
                // ��� �߰�
                break;

            case Items.Lasers:
                // Ŭ���� 2�߾� �߻�
                LasersItemUse(player);
                break;

            case Items.Enlarge:
                // �е��� 1.5�� Ŀ��(����)
                EnalargeItemUse(player);
                break;

            case Items.Catch:
                // ���� ƨ�����ʰ� �е鿡 �޶����
                CatchItemUse();
                break;

            case Items.Slow:
                // �� �ӵ� ����
                SlowItemUse();
                break;

            case Items.Disruption:
                // �� 2�� �߰�
                DisruptionItemUse();
                break;
            case Items.Power:
                // ���ݷ� ����
            break;

        }
    }

    private void DisruptionItemUse()
    {
        _firstBall = Managers.Game.CurrentBalls[0];
        Rigidbody2D firstBallRb = _firstBall.GetComponent<Rigidbody2D>();
        Vector2 firstBallVec = firstBallRb.velocity;

        float seta;
        seta = Mathf.Atan2(firstBallVec.y, firstBallVec.x);

        // ������
        GameObject secondBall = Instantiate(_firstBall, _firstBall.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
        Managers.Game.CurrentBalls.Add(secondBall);
        ArkanoidBall secondArkanoidBall = secondBall.GetComponent<ArkanoidBall>();
        secondArkanoidBall.isLaunch = true;
        Rigidbody2D secondBallRb = secondBall.GetComponent<Rigidbody2D>();
        if (firstBallVec.x == 0)
        {
            secondBallRb.velocity = new Vector2(firstBallVec.y * Mathf.Cos(45), firstBallVec.y * Mathf.Sin(45));
        }
        else
        {
            secondBallRb.velocity = new Vector2(firstBallVec.x, firstBallVec.x * Mathf.Tan(seta - 45));
        }

        // ������
        GameObject thirdBall = Instantiate(_firstBall, _firstBall.transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
        Managers.Game.CurrentBalls.Add(thirdBall);
        ArkanoidBall thirdArkanoidBall = thirdBall.GetComponent<ArkanoidBall>();
        thirdArkanoidBall.isLaunch = true;
        Rigidbody2D thirdBallRb = thirdBall.GetComponent<Rigidbody2D>();
        if (firstBallVec.x == 0)
        {
            thirdBallRb.velocity = new Vector2(-firstBallVec.y * Mathf.Cos(45), firstBallVec.y * Mathf.Sin(45));
        }
        else
        {
            thirdBallRb.velocity = new Vector2(-firstBallVec.x, firstBallVec.x * Mathf.Tan(seta - 45));
        }
    }

    private void SlowItemUse()
    {
        _mainBall = GameObject.Find("BallPrefab(Clone)").GetComponent<ArkanoidBall>();
        _originSpeed = _mainBall.ballMaxSpeed;
        _mainBall.SetMaxSpeed(_originSpeed / 2);
        StartCoroutine(OriginBallSpeed());
    }

    IEnumerator OriginBallSpeed()
    {
        yield return new WaitForSeconds(2f);
        _mainBall.SetMaxSpeed(_originSpeed);
    }



    private void LasersItemUse(GameObject player)
    {
        var bullet1 = Instantiate(bullet, player.transform);
        bullet1.transform.position += new Vector3(-0.5f, 1f, 0f);
        var bullet2 = Instantiate(bullet, player.transform);
        bullet2.transform.position += new Vector3(0.5f, 1f, 0f);
    }

    private void EnalargeItemUse(GameObject player)
    {
        var playerScale = player.transform.localScale;
        player.transform.localScale = new Vector3(playerScale.x * 1.5f, playerScale.y, playerScale.z);
    }


}