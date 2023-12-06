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
    [SerializeField] private AudioSliderSetting BGMAudioSliderSetting;
    [SerializeField] private AudioSliderSetting SFXAudioSliderSetting;

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

        // #3. ���� ������ üũ
        DataCheck();
    }

    private void Start()
    {
        dataClearButton.onClick.AddListener(DataClear);
        AudioCheck();
    }

    #region Menu

    private void OpenMenu(int menuIndex)
    {
        SFX.Instance.PlayOneShot(SFX.Instance.btnClick);

        foreach (var menu in menus)
        {
            menu.SetActive(false);
        }

        menus[menuIndex].SetActive(true);
    }

    #endregion

    #region Data

    private void DataCheck()
    {
        if (!PlayerPrefs.HasKey(Data.LevelUnlock))
        {
            PlayerPrefs.SetInt(Data.LevelUnlock, 0);
        }

        if (!PlayerPrefs.HasKey(Data.BestScore))
        {
            PlayerPrefs.SetFloat(Data.BestScore, 0);
        }

        if (!PlayerPrefs.HasKey(Data.TimeRecord))
        {
            PlayerPrefs.SetFloat(Data.TimeRecord, 0);
        }

        if (!PlayerPrefs.HasKey(Data.BGM))
        {
            PlayerPrefs.SetFloat(Data.BGM, 1f);
        }

        if (!PlayerPrefs.HasKey(Data.SFX))
        {
            PlayerPrefs.SetFloat(Data.SFX, 1f);
        }
    }

    /// <summary>
    /// ������ �ʱ�ȭ
    /// </summary>
    private void DataClear()
    {
        SFX.Instance.PlayOneShot(SFX.Instance.btnClick);
        PlayerPrefs.DeleteAll();
    }

    #endregion

    #region Audio

    private void AudioCheck()
    {
        //BGM
        BGMAudioSliderSetting.audioSlider.value = PlayerPrefs.GetFloat(Data.BGM);
        BGMAudioSliderSetting.BGMAuidoControl(BGMAudioSliderSetting.audioSlider.value);

        //SFX
        SFXAudioSliderSetting.audioSlider.value = PlayerPrefs.GetFloat(Data.SFX);
        SFXAudioSliderSetting.SFXAuidoControl(SFXAudioSliderSetting.audioSlider.value);
    }

    #endregion
}
