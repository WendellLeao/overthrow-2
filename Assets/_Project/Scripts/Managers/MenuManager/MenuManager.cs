using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public sealed class MenuManager : MonoBehaviour
{
    [Header("Menus Object")]
    [SerializeField] private GameObject _mainMenuObject;
    [SerializeField] private GameObject _loadingScreenObject;
    [SerializeField] private GameObject _settingsMenuObject;
    [SerializeField] private GameObject _videoSettingsMenuObject;
    [SerializeField] private GameObject _audioSettingsMenuObject;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _showSettingsMenuButton;
    [SerializeField] private Button _quitGameButton;
    
    [Header("Settings Menu Buttons")]
    [SerializeField] private Button _settingsMenuBackButton;
    [SerializeField] private Button _showVideoMenuButton; 
    [SerializeField] private Button _showAudioMenuButton; 
    [SerializeField] private Button _audioMenuBackButton;
    [SerializeField] private Button _videoMenuBackButton;

    [Header("Scene Handler")]
    [SerializeField] private AsyncSceneHandler _asyncSceneHandler;

    private void ShowMenu(Menu menu)
    {
        DeactiveMenus();

        switch(menu)
        {
            case Menu.MAIN:
            {
                HandleMainMenu();
                break;
            }
            case Menu.LOADING_SCREEN:
            {
                _loadingScreenObject.SetActive(true);
                break;
            }
            case Menu.SETTINGS:
            {
                _settingsMenuObject.SetActive(true);
                break;
            }
            case Menu.VIDEO_SETTINGS:
            {
                _videoSettingsMenuObject.SetActive(true);
                break;
            }
            case Menu.AUDIO_SETTINGS:
            {
                _audioSettingsMenuObject.SetActive(true);
                break;
            }
        }
    }
    
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
    
    private void Start()
    {
        ResumeGame();

        SetMenusObjectPosition();

        ShowMenu(Menu.MAIN);

        StartCoroutine(DelayToPlayGameTheme(0.2f));///
    }

    private void SubscribeEvents()
    {
        _continueButton.onClick.AddListener(OnClick_StartGame);
        _newGameButton.onClick.AddListener(OnClick_StartNewGame);
        
        _showSettingsMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.SETTINGS); });
        
        _settingsMenuBackButton.onClick.AddListener(delegate { ShowMenu(Menu.MAIN); });
        
        _showVideoMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.VIDEO_SETTINGS); });
        _showAudioMenuButton.onClick.AddListener(delegate { ShowMenu(Menu.AUDIO_SETTINGS); });
        
        _videoMenuBackButton.onClick.AddListener(delegate { ShowMenu(Menu.SETTINGS); });
        _audioMenuBackButton.onClick.AddListener(delegate { ShowMenu(Menu.SETTINGS); });

        _quitGameButton.onClick.AddListener(delegate { Application.Quit(); });
    }

    private void UnsubscribeEvents()
    {
        _continueButton.onClick.RemoveAllListeners();
        _newGameButton.onClick.RemoveAllListeners();
        
        _showSettingsMenuButton.onClick.RemoveAllListeners();
        
        _settingsMenuBackButton.onClick.RemoveAllListeners();
        
        _showVideoMenuButton.onClick.RemoveAllListeners();
        _showAudioMenuButton.onClick.RemoveAllListeners();
        
        _videoMenuBackButton.onClick.RemoveAllListeners();
        _audioMenuBackButton.onClick.RemoveAllListeners();

        _quitGameButton.onClick.RemoveAllListeners();
    }
    
    private void DeactiveMenus()
    {
        _mainMenuObject.SetActive(false);
        _loadingScreenObject.SetActive(false);
        _settingsMenuObject.SetActive(false);
        _videoSettingsMenuObject.SetActive(false);
        _audioSettingsMenuObject.SetActive(false);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    
    private void HandleMainMenu()
    {
        _mainMenuObject.SetActive(true);

        int firstLevelIndex = (int)SceneEnum.LEVEL_01;
        
        _continueButton.gameObject.SetActive(SaveSystem.GetLocalData().CurrentSceneIndex > firstLevelIndex);
    }

    private void OnClick_StartGame()
    {
        StartLoadedLevel();
    }

    private void OnClick_StartNewGame()
    {
        ShowMenu(Menu.LOADING_SCREEN);
        
        SaveSystem.ResetCurrentSceneIndex();

        SaveSystem.SaveGameData();

        _asyncSceneHandler.LoadSingleSceneAsync(SceneEnum.LEVEL_01);
    }

    private void StartLoadedLevel()
    {
        ShowMenu(Menu.LOADING_SCREEN);

        int loadedSceneIndex = SaveSystem.LoadGameData().CurrentSceneIndex;
        
        _asyncSceneHandler.LoadSingleSceneAsync(loadedSceneIndex);
    }
    
    private void SetMenusObjectPosition()
    {
        _mainMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _loadingScreenObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _settingsMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _videoSettingsMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _audioSettingsMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    
    private IEnumerator DelayToPlayGameTheme(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        SoundManager.instance.PlaySound2D(Sound.GAME_THEME);
    }
}
