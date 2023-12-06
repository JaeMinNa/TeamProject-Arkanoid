using UnityEngine;
using TMPro;

public class MainSceneUI : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject[] lifes;

    [Header("Time Attack")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI bestTimerText;

    [Header("Score Board")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    private string KeyName = "BestScore";
    private float bestscore = 0;

    [Header("Popup")]
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private GameObject nextStagePopup;
    [SerializeField] private GameObject timeAttackPopup;

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

    public void SetBestScoreUI()
    {
        bestscore = PlayerPrefs.GetFloat(KeyName, 0);
        bestScoreText.text = $"�ְ� ��� : {bestscore}";

        if (Managers.Game.Score > bestscore)
        {
            PlayerPrefs.SetFloat(KeyName, Managers.Game.Score);
        }
    }

    #endregion

    #region Show Popup

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
                bestTimerText.gameObject.SetActive(true);
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

    #endregion
}
