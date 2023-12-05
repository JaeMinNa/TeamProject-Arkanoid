using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI BestscoreText;
    [SerializeField] private GameObject[] lifes;

    [Header("Popup")]
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private GameObject nextStagePopup;
    [SerializeField] private GameObject RankPopup;


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

    public void ShowGameOver()
    {
        BGM.Instance.Play(BGM.Instance.gameover, false);

        gameOverPopup.SetActive(true);
    }

    public void ShowNextStage()
    {
        BGM.Instance.Play(BGM.Instance.nextstage, false);

        nextStagePopup.SetActive(true);
    }

    // Ŭ���� ���_Main_���� ����� �ְ� ���
    private string KeyName = "BestScore";
    private float bestscore = 0;

    void Start()
    {
        bestscore = PlayerPrefs.GetFloat(KeyName, 0);
        BestscoreText.text = $"�ְ� ��� : {bestscore.ToString()}";
    }

    private void LateUpdate()
    {
        if (Managers.Game.Score > bestscore)
        {
            PlayerPrefs.SetFloat(KeyName, Managers.Game.Score);
        }
    }

}
