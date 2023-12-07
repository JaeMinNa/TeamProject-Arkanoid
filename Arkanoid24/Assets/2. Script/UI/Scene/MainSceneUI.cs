using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSceneUI : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject[] lifes;
    [SerializeField] private Button settingButton;

    [Header("Time Attack")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    [SerializeField] private TextMeshProUGUI currentRecordText;
    [SerializeField] private TextMeshProUGUI bestRecordText;

    [Header("Score Board")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI[] rankTexts;

    [Header("Popup")]
    [SerializeField] private GameObject settingPopup;
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private GameObject nextStagePopup;
    [SerializeField] private GameObject rankingPopup;
    [SerializeField] private GameObject timeAttackPopup;

    private void Start()
    {
        settingButton.onClick.AddListener(ShowSettings);
    }

    #region Set UI

    public void SetScoreUI(float score)
    {
        scoreText.text = $"���� : {score}";
    }

    public void SetLifeUI(bool isDown, int num)
    {
        if (isDown)
        {
            lifes[num].SetActive(false);
        }
        else
        {
            lifes[num].SetActive(true);
        }
    }

    #endregion

    #region Show Popup

    public void ShowSettings()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.btnClick);
        Managers.Game.State = GameState.Pause;
        settingPopup.SetActive(true);
    }

    public void ShowGameOver()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.gameover);
        gameOverPopup.SetActive(true);
    }

    public void ShowNextStage()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.nextstage);
        nextStagePopup.SetActive(true);
    }

    public void ShowRanking()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.nextstage);
        rankingPopup.SetActive(true);
    }

    public void ShowTimeAttack()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.nextstage);
        timeAttackPopup.SetActive(true);
    }

    #endregion

    #region Mode Method

    /// <summary>
    /// ��忡 ���� UI ����
    /// </summary>
    public void StartModeUI(GameMode mode)
    {
        switch (mode) 
        {
            case GameMode.Main:
                scoreText.gameObject.SetActive(true); 
                break;

            case GameMode.Infinity:
                scoreText.gameObject.SetActive(true);
                bestScoreText.gameObject.SetActive(true);
                break;

            case GameMode.TimeAttack:
                timerText.gameObject.SetActive(true);
                bestTimeText.gameObject.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// [Ÿ�� ����] Ÿ�̸� UI ����
    /// </summary>
    /// <param name="remainTime">���� �ð�</param>
    public void SetTimerUI(float remainTime)
    {
        timerText.text = string.Format(remainTime.ToString("F2"));
    }

    /// <summary>
    /// [���� ���] ���� ������ UI ����
    /// </summary>
    /// <param name="num"></param>
    public void SetCurrentLifeUI(int num)
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            if (i < num) lifes[i].SetActive(true);
            else lifes[i].SetActive(false);
        }
    }

    /// <summary>
    /// [���� ���] �ְ� ���� ����
    /// </summary>
    /// <param name="bestScore"></param>
    public void SetBestScoreUI(float bestScore)
    {
        bestScoreText.text = $"�ְ� ���� : {bestScore}";
    }

    /// <summary>
    /// [Ÿ�� ����] �ְ� ��� ����
    /// </summary>
    /// <param name="bestTime">�ְ� ���</param>
    public void SetBestTimeUI(float bestTime)
    {
        bestTimeText.text = $"�ְ���  {bestTime:F2}��";
    }

    /// <summary>
    /// [Ÿ�� ����] ��� ��� ����
    /// </summary>
    /// <param name="record">���� ���</param>
    /// <param name="bestRecord">�ְ� ���</param>
    public void SetResultRecordUI(float record, float bestRecord)
    {
        currentRecordText.text = $"������  {record:F2}��";
        bestRecordText.text = $"�ְ���  {bestRecord:F2}��";
    }

    public void SetRankingUI()
    {
        for (int i = 0; i < rankTexts.Length; i++)
        {
            rankTexts[i].text = $"{i + 1}��  {Managers.Game.RankScores[i]}��";
        }
    }

    #endregion
}
