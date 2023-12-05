using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MainScene : MonoBehaviour
{
    private StageBlueprint stageBlueprint;
    private EdgeCollider2D screenEdge;

    #region MonoBehaviour

    private void Awake()
    {
        Managers.Resource.Initialize();
        Managers.Game.Initialize();

        screenEdge = GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {
        InitMainGame();
    }

    #endregion

    private void InitMainGame()
    {
        // #1. ������ 3���� ���� 
        Managers.Game.Life = 3;

        // #2. ���ھ� 0������ ����
        //Managers.Game.Score = 0;

        Managers.Player.CameraSpawn();

        // #3. ���� ������ �´� �������� ����
        CreateStage();

        Managers.Player.PlayerSpawn();

        // #4. �� ���� �� ���
        Managers.Game.InstanceBall();
    }

    /// <summary>
    /// ���赵���� ���� �������� �� ����
    /// </summary>
    private void CreateStage()
    {
        stageBlueprint = Managers.Game.CurrentStage();
        Instantiate(stageBlueprint.StageMap);
    }
}
