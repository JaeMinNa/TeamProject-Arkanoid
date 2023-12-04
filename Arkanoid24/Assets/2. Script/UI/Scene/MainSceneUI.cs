using UnityEngine;
using TMPro;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject[] lifes;

    [Header("Popup")]
    [SerializeField] private GameObject gameOverPopup;
    [SerializeField] private GameObject nextStagePopup;

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
}
