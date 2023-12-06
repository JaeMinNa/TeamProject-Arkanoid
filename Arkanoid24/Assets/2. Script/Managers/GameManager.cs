using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public List<GameObject> CurrentBalls = new();

    #region Properties

    public MainScene Main { get; private set; }
    public MainSceneUI MainUI { get; private set; }
    public GameState State { get; set; }
    public GameMode Mode { get; set; } = GameMode.Main;
    public StageBlueprint[] Stages { get; private set; }
    public int CurrentLevel { get; set; }
    public int Bricks { get; set; }
    public int Life { get; set; }
    public float Score { get; set; }

    #endregion

    #region Properties - Mode

    public float Timer { get; set; }
    public float BestScore { get; set; }

    #endregion

    #region Initialize

    /// <summary>
    /// ���� �Ŵ��� �ʱ�ȭ
    /// </summary>
    public void Initialize()
    {
        Stages = Managers.Resource.GetStages();
    }

    /// <summary>
    /// ���� �� OnStart �ʱ�ȭ
    /// </summary>
    public void InitScene()
    {
        Main = Object.FindObjectOfType<MainScene>();
        MainUI = Object.FindObjectOfType<MainSceneUI>();

        CurrentBalls.Clear();
        State = GameState.Play;
        Bricks = Stages[CurrentLevel].Bricks;

        InitMode();
    }

    /// <summary>
    /// ���� ��忡 ���� �ʱ�ȭ
    /// </summary>
    private void InitMode()
    {
        MainUI.StartModeUI(Mode);

        switch (Mode) 
        {
            case GameMode.TimeAttack:
                Timer = 20;
                MainUI.SetTimerUI(Timer);
                break;
            // ���Ѹ�� => ����, ������ ����
            case GameMode.Infinity:
                MainUI.SetScoreUI(Score);
                MainUI.SetCurrentLifeUI(Life);
                break;
            case GameMode.Versus:
                break;
        }
    }

    public StageBlueprint GetCurrentStage()
    {
        return Stages[CurrentLevel];
    }

    #endregion

    #region Game Play Methods

    public void InstanceBall()
    {
        var paddle = GameObject.FindWithTag("Player");
        var ballStartPos = new Vector2(paddle.transform.position.x, paddle.transform.position.y + 0.3f);
        var ballClone = Managers.Resource.Instantiate("BallPrefab", ballStartPos);
        CurrentBalls.Add(ballClone);
    }

    public void AddScore(float score)
    {
        Bricks--;
        if (MainUI == null) return;
        if (Bricks == 0)
        {
            State = GameState.Pause;
            Managers.Skill.ResetSkill(true);
            GameClearMode();
        }

        Score += score;
        MainUI.SetScoreUI(Score);
    }

    public void LifeUp()
    {
        Life = Mathf.Clamp(Life, 0, 2);
        MainUI.SetLifeUI(false, Life);
        Life++;
    }

    public void LifeDown(GameObject ball)
    {
        CurrentBalls.Remove(ball);

        if (CurrentBalls.Count != 0) return;
        Managers.Skill.BallIncreaseSpeed = 0f;
        if (MainUI == null)
        {
            InstanceBall();
            return;
        }

        Life--;
        MainUI.SetLifeUI(true, Life);

        if (Life == 0)
        {
            GameOver();
        }
        else
        {
            InstanceBall();
        }
    }

    #endregion

    #region Game Result Methods

    /// <summary>
    /// ���� ��忡 ���� Ŭ���� ����
    /// </summary>
    private void GameClearMode()
    {
        switch (Mode)
        {
            case GameMode.Main:
                LevelClear();
                MainUI.ShowNextStage();
                break;
            case GameMode.TimeAttack:
                MainUI.ShowTimeAttack();
                break;
            // Ŭ���� ��, �˾� �� ���� �ٷ�, ���� ��������
            case GameMode.Infinity:
                LevelClear();
                SceneLoader.Instance.ChangeScene("Main");
                break;
            case GameMode.Versus:
                break;
        }
    }

    public void GameOver()
    {
        State = GameState.Pause;
        MainUI.ShowGameOver();
        Managers.Skill.ResetSkill(true);
    }

    public void LevelClear()
    {
        CurrentLevel++;

        if (CurrentLevel > PlayerPrefs.GetInt(Data.LevelUnlock, 0))
        {
            PlayerPrefs.SetInt(Data.LevelUnlock, CurrentLevel);
        }
    }

    #endregion
}
