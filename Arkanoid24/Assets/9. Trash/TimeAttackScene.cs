using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAttackScene : MonoBehaviour
{
    private StageBlueprint stageBlueprint;
    private EdgeCollider2D screenEdge;

    #region MonoBehaviour

    private void Awake()
    {
        Managers.Resource.Initialize();
        Managers.Game.Initialize();

        screenEdge = GetComponent<EdgeCollider2D>();
        //screenEdge.GenerateCameraBounds();
    }

    private void Start()
    {
        InitTAGame();
    }


    #endregion

    private void InitTAGame()
    {
        // #1. ������ 3���� ���� 
        Managers.Game.Life = 3;

        // #2. ���ھ� 0������ ����
        //Managers.Game.Score = 0;

        // #3. ���� ������ �´� �������� ����
        CreateStage();

        // #4. �� ���� �� ���
        Managers.Ball.CreateBalls();
    }

    /// <summary>
    /// ���赵���� ���� �������� �� ����
    /// </summary>
    private void CreateStage()
    {
        stageBlueprint = Managers.Game.GetCurrentStage();
        Instantiate(stageBlueprint.StageMap);
    }

}
