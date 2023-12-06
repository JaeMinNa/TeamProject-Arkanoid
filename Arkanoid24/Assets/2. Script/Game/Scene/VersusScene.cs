
using UnityEngine;

public class VersusScene : MonoBehaviour
{
    private VersusLevelBlueprint versusLevelBlueprint;

    #region MonoBehaviour

    private void Awake()
    {
        Managers.Resource.Initialize();
        Managers.Versus.Initialize();
    }

    private void Start()
    {
        InitMainGame();
    }

    #endregion

    private void InitMainGame()
    {
        // #0. �� �ε�
        SceneLoader.Instance.OnSceneLoaded();

        // # 1. Camera, Player, Stage Setting (ī�޶�, �÷��̾�, ��������)
        Managers.Player.CameraSpawn();
        Managers.Player.PlayerSpawn();
        CreateStage();

        // # 2. Assign Player To Ball(Create)
        foreach(var player in Managers.Player.GetActivePlayers())
        {
            GameObject ball = Managers.Game.CreateBall(player);

            var ballPreference = ball.GetComponent<BallPreference>();
            ballPreference.AssignPlayer(player);

            Managers.Ball.AssignBallToPlayer(player, ball);
        }
    }

    /// <summary>
    /// ���赵���� ���� �������� �� ����
    /// </summary>
    private void CreateStage()
    {
        versusLevelBlueprint = Managers.Versus.CurrentStage();
        Instantiate(versusLevelBlueprint.StageMap);
    }
}
