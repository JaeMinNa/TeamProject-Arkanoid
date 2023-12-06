
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

        // # 1. Setting (ī�޶�, �÷��̾�, ��������)
        Managers.Player.CameraSpawn();
        Managers.Player.PlayerSpawn();
        CreateStage();


        // # 2. Ball Create To Assgin Player
        foreach (var player in Managers.Player.GetActivePlayers())
        {
            GameObject ball = Managers.Game.CreateBall(player);

            var ballPreference = ball.GetComponent<BallPreference>();
            ballPreference.AssignPlayer(player); // �÷��̾� �Ҵ�

            Managers.Ball.AssignBallToPlayer(player, ball); // �� �Ŵ����� ���
        }

        // #2. �� ���� �� ���
        // Managers.Versus.InstanceBall();
        //Managers.Versus.InstanceBall(VersusManager.player1Index);
        //Managers.Versus.InstanceBall(VersusManager.player2Index);

        Managers.Game.Mode = GameMode.Versus;
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
