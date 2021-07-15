using UnityEngine;
using UnityEngine.UI;

public sealed class MenuManager : MonoBehaviour
{
    [Header("Menu Containers")]
    [SerializeField] private GameObject _mainMenuObject;
    [SerializeField] private GameObject _loadingScreenObject;
    [SerializeField] private GameObject _settingsMenuObject;

    [Header("Menu Buttons")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _settingsMenuButton;
    [SerializeField] private Button _quitButton;

    [Header("Scene Handler")]
    [SerializeField] private AsyncSceneHandler _asyncSceneHandler;

    public void ShowMenu(Menu menu)
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

        SetMenuObjectPosition();

        ShowMenu(Menu.MAIN);

        SoundManager.instance.PlaySoundtrack();
    }

    private void SubscribeEvents()
    {
        _continueButton.onClick.AddListener(OnClick_StartGame);
        _newGameButton.onClick.AddListener(OnClick_StartNewGame);
        
        _settingsMenuButton.onClick.AddListener(OnClick_ShowSettingsMenu);

        _quitButton.onClick.AddListener(OnClick_Quit);
    }

    private void UnsubscribeEvents()
    {
        _continueButton.onClick.RemoveAllListeners();
        _newGameButton.onClick.RemoveAllListeners();
        
        _settingsMenuButton.onClick.RemoveAllListeners();

        _quitButton.onClick.RemoveAllListeners();
    }

    private void DeactiveMenus()
    {
        _mainMenuObject.SetActive(false);
        _loadingScreenObject.SetActive(false);
        _settingsMenuObject.SetActive(false);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void SetMenuObjectPosition()
    {
        _mainMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _loadingScreenObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _settingsMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    
    private void HandleMainMenu()
    {
        _mainMenuObject.SetActive(true);

        int firstLevelIndex = (int)SceneEnum.LEVEL_01;
        
        _continueButton.gameObject.SetActive(SaveSystem.GetLocalData().currentSceneIndex > firstLevelIndex);
    }

    private void OnClick_StartGame()
    {
        StartLoadedLevel();
    }

    private void OnClick_StartNewGame()
    {
        SaveSystem.DeleteSave();
        
        StartFirstLevel();
    }

    private void StartLoadedLevel()
    {
        ShowMenu(Menu.LOADING_SCREEN);

        int loadedSceneIndex = SaveSystem.LoadGameData().currentSceneIndex;
        
        _asyncSceneHandler.LoadSingleSceneAsync(loadedSceneIndex);
    }
    
    private void StartFirstLevel()
    {
        ShowMenu(Menu.LOADING_SCREEN);

        _asyncSceneHandler.LoadSingleSceneAsync(SceneEnum.LEVEL_01);
    }

    private void OnClick_ShowSettingsMenu()
    {
        ShowMenu(Menu.SETTINGS);
    }

    private void OnClick_Quit()
    {
        Debug.Log("Quit!");

        Application.Quit();
    }
}