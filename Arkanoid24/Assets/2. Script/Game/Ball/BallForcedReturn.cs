using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForcedReturn : MonoBehaviour
{
    [SerializeField] private int maxWallHitCount;
    private int currentWallHitCount = 0;
    private GameObject BallOwner;
    void Start()
    {
        BallOwner = gameObject.GetComponent<BallPreference>().BallOwner;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector2 ownerPaddlePosition = BallOwner.transform.position;
        Vector2 ballPosition = gameObject.transform.position;
        //1. ���� �浹�ϸ� currentWallHitCount ����
        if (collision.gameObject.tag == "Wall")
        {
            currentWallHitCount++;
        }
        else
        {
            currentWallHitCount = 0;
        }
        //2. current�� max �̻��̸�
        if (currentWallHitCount >= maxWallHitCount)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(ownerPaddlePosition.x - ballPosition.x, ownerPaddlePosition.y - ballPosition.y);
            currentWallHitCount = 0;
        }
    }
}
