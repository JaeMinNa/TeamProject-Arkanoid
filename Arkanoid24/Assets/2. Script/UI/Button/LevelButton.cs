using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Managers.Game.CurrentLevel = level;
        SceneManager.LoadScene("Main");
    }
}
