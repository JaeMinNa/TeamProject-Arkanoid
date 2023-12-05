using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class VersusScene : MonoBehaviour
{
    private VersusLevelBlueprint versusLevelBlueprint;
    private EdgeCollider2D screenEdge;

    #region MonoBehaviour

    private void Awake()
    {
        Managers.Resource.Initialize();
        Managers.Versus.Initialize();

        screenEdge = GetComponent<EdgeCollider2D>();
        screenEdge.GenerateCameraBounds();
    }

    private void Start()
    {
        InitMainGame();
    }

    #endregion

    private void InitMainGame()
    {
        // #1. ���� ������ �´� �������� ����
        CreateStage();

        Managers.Player.PlayerSpawn();

        // #2. �� ���� �� ���
        Managers.Versus.InstanceBall();
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
