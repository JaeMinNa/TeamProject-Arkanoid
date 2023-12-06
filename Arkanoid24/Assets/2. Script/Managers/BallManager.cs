
using System.Collections.Generic;
using UnityEngine;

public class BallManager
{
    private Dictionary<GameObject, List<GameObject>> _playerBallMap =
        new Dictionary<GameObject, List<GameObject>>();


    public void AssignBallToPlayer(GameObject player, GameObject ball)
    {
        // �ش� �÷��̾ ���� �� ����Ʈ�� ���ٸ�?
        if (!_playerBallMap.ContainsKey(player))
        {
            _playerBallMap[player] = new List<GameObject>();
        }

        // �� ����Ʈ�� �߰�
        _playerBallMap[player].Add(ball);
    }

    public List<GameObject> GetBallsForPlayer(GameObject player)
    {
        if(_playerBallMap.TryGetValue(player, out List<GameObject> balls))
        {
            return balls;
        }

        return new List<GameObject>(); // ���� ��� �� ������Ʈ ����Ʈ�� ��ȯ
    }

    public void RemovePlayer(GameObject player)
    {
        if(_playerBallMap.ContainsKey(player))
        {
            _playerBallMap.Remove(player);
        }
    }

    public void RemoveBallFromPlayer(GameObject player, GameObject ball)
    {
        if(_playerBallMap.ContainsKey(player))
        {
            _playerBallMap[player].Remove(ball);
        }
    }

    public void ReleaseAll()
    {
        _playerBallMap.Clear();
    }
}
