using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private Image board;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(LevelStart);
    }

    /// <summary>
    /// �������� ������ üũ Ȯ�ο�
    /// </summary>
    private void OnEnable()
    {
        // ��� �������� ���� ���, ��ư ���
        if (level <= PlayerPrefs.GetInt("LevelsUnlocked"))
        {
            board.color = Color.white;
        }
        else
        {
            button.interactable = false;
            board.color = new Color32(255, 0, 0, 200);
        }
    }

    private void LevelStart()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.btnClick);

        Managers.Game.CurrentLevel = level;
        Managers.Game.Mode = GameMode.Main;
        SceneLoader.Instance.ChangeScene("Main");
    }
}
