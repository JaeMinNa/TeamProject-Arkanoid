using UnityEngine;
using TMPro;

public class MainSceneUI : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private GameObject[] lifes;

    [Header("Time Attack")]
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Score Board")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI BestscoreText;
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
        BestscoreText.text = $"�ְ� ��� : {bestscore}";

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
