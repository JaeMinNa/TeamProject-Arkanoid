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
            button.enabled = true;
            board.color = Color.white;
        }
        else
        {
            button.enabled = false;
            board.color = Color.black;
        }
    }

    /// <summary>
    /// �ش� ���� �÷���
    /// </summary>
    private void LevelStart()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.btnClick);

        Managers.Game.Mode = GameMode.Main;
        Managers.Game.CurrentLevel = level;
        SceneLoader.Instance.ChangeScene("Main");
    }
}
