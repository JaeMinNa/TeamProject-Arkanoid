using System.Collections;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private StageBlueprint stageBlueprint;

    #region MonoBehaviour

    private void Awake()
    {
        Managers.Resource.Initialize();
        Managers.Game.Initialize();
    }

    private void Start()
    {
        InitMainGame();
    }

    #endregion

    private void InitMainGame()
    {
        // #1. �� �ε�
        SceneLoader.Instance.OnSceneLoaded();

        // #2. ���� ������ �´� �������� ����
        CreateStage();

        // #3. ���� ��� ����
        GameModeSetting();

        // #4. �� ���� �� ���
        Managers.Game.InstanceBall();
    }

    /// <summary>
    /// ���赵���� ���� �������� �� ����
    /// </summary>
    private void CreateStage()
    {
        stageBlueprint = Managers.Game.GetCurrentStage();
        Instantiate(stageBlueprint.StageMap);
    }

    /// <summary>
    /// ���� ��忡 ���� ����
    /// </summary>
    private void GameModeSetting()
    {
        switch (Managers.Game.Mode)
        {
            case GameMode.Main:
                Managers.Game.Life = 3;
                Managers.Game.Score = 0;
                break;

            case GameMode.TimeAttack:
                Managers.Game.Life = 3;
                StartCoroutine(StartTimer());
                break;

            case GameMode.Infinity:
                break;

            case GameMode.Versus:
                break;
        }
    }

    /// <summary>
    /// Ÿ�̸� ����, Ÿ�̸� ���� �� => ���� ����
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartTimer()
    {
        while (Managers.Game.Timer > 0)
        {
            if (Managers.Game.State != GameState.Play) break;
            Managers.Game.Timer -= Time.deltaTime;
            Managers.Game.MainUI.SetTimerUI(Managers.Game.Timer);
            yield return null;
        }

        if (Managers.Game.Timer <= 0)
        {
            Managers.Game.Timer = 0;
            Managers.Game.MainUI.SetTimerUI(0);
            Managers.Game.GameOver();
        }
    }
}
