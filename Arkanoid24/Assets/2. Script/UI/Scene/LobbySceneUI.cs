using UnityEngine;
using UnityEngine.UI;

public class LobbySceneUI : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject[] menus;
    [SerializeField] private Button levelButtons;
    [SerializeField] private Button settingsButtons;
    [SerializeField] private Button creditsButtons;

    [Header("Level")]
    [SerializeField] private LevelButton[] levels;
    [SerializeField] private GameObject[] specialLevels;

    [Header("Settings")]
    [SerializeField] private Button dataClearButton;

    [Header("Others")]
    [SerializeField] private Button[] backButtons;

    private void Awake()
    {
        // #1. �޴� ��ư �޼��� Ȱ��ȭ
        levelButtons.onClick.AddListener(delegate { OpenMenu(1); });
        settingsButtons.onClick.AddListener(delegate { OpenMenu(2); });
        creditsButtons.onClick.AddListener(delegate { OpenMenu(3); });

        // #2. �� ��ư �ʱ�ȭ
        foreach (var backBtn in backButtons)
        {
            backBtn.onClick.AddListener(delegate { OpenMenu(0); });
        }

        dataClearButton.onClick.AddListener(DataClear);

        // #3. ���� ������ üũ
        if (!PlayerPrefs.HasKey("LevelsUnlocked"))
        {
            PlayerPrefs.SetInt("LevelsUnlocked", 0);
        }
    }

    private void OpenMenu(int menuIndex)
    {
        foreach (var menu in menus) 
        {
            menu.SetActive(false);
        }

        menus[menuIndex].SetActive(true);
    }

    private void DataClear()
    {
        PlayerPrefs.DeleteAll();
    }
}
