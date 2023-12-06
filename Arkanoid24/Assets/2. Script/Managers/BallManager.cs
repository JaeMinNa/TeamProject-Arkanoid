
using System.Collections.Generic;
using UnityEngine;

public class BallManager
{
    private Dictionary<GameObject, List<GameObject>> playerBallMap =
        new Dictionary<GameObject, List<GameObject>>();


    public void AssignBallToPlayer(GameObject player, GameObject ball)
    {
        // �ش� �÷��̾ ���� �� ����Ʈ�� ���ٸ�?
        if (!playerBallMap.ContainsKey(player))
        {
            playerBallMap[player] = new List<GameObject>();
        }

        // �� ����Ʈ�� �߰�
        playerBallMap[player].Add(ball);
    }

    public List<GameObject> GetBallsForPlayer(GameObject player)
    {
        if(playerBallMap.TryGetValue(player, out List<GameObject> balls))
        {
            return balls;
        }

        return new List<GameObject>(); // ���� ��� �� ������Ʈ ����Ʈ�� ��ȯ
    }

    public void RemovePlayer(GameObject player)
    {
        if(playerBallMap.ContainsKey(player))
        {
            playerBallMap.Remove(player);
        }
    }

    public void RemoveBallFromPlayer(GameObject player, GameObject ball)
    {
        if(playerBallMap.ContainsKey(player))
        {
            playerBallMap[player].Remove(ball);
        }
    }
}
