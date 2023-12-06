
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

    // ��� Ȱ��ȭ�� �÷��̾��� ��� ������ ����Ʈ�� ��ȯ
    public List<GameObject> GetAllBalls()
    {
        List<GameObject> allBalls = new List<GameObject>();

        foreach (var playerBalls in _playerBallMap.Values)
        {
            allBalls.AddRange(playerBalls);
        }

        return allBalls;
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
        if(_playerBallMap.ContainsKey(player) || player != null)
        {
            _playerBallMap[player].Remove(ball);
        }
    }

    public void CreateBallForPlayer(GameObject player)
    {
        var ballStartPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f);
        var ball = Managers.Resource.Instantiate("BallPrefab", ballStartPos);

        var ballPreference = ball.GetComponent<BallPreference>();
        ballPreference.AssignPlayer(player);

        AssignBallToPlayer(player, ball);
    }

    public void CreateBalls()
    {
        foreach(var player in Managers.Player.GetActivePlayers())
        {
            CreateBallForPlayer(player);
        }
    }

    public void ReleaseAll()
    {
        _playerBallMap.Clear();
    }
}
