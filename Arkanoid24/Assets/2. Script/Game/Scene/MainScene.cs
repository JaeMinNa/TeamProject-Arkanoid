using System.Collections;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private StageBlueprint stageBlueprint;

    #region MonoBehaviour

    private void Start()
    {
        InitMainGame();
    }

    #endregion

    private void InitMainGame()
    {
        // #1. �Ŵ��� ����
        Managers.Game.InitScene();

        // #2. �� �ε�
        SceneLoader.Instance.OnSceneLoaded();

        // #3. ���� ������ �´� �������� ����
        CreateStage();

        // #4. ���� ��� ����
        GameModeSetting();

        // #5. �� ���� �� ���
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
