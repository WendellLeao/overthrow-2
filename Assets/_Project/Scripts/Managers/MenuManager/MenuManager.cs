using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class MenuManager : MonoBehaviour
{
    [Header("Menu Containers")]
    [SerializeField] private GameObject _mainMenuObject;
    [SerializeField] private GameObject _loadingScreenObject;

    [Header("Menu Buttons")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _quitButton;

    [Header("Scene Handler")]
    [SerializeField] private AsyncSceneHandler _asyncSceneHandler;

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

        _quitButton.onClick.AddListener(OnClick_Quit);
    }

    private void UnsubscribeEvents()
    {
        _continueButton.onClick.RemoveAllListeners();
        _newGameButton.onClick.RemoveAllListeners();

        _quitButton.onClick.RemoveAllListeners();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void SetMenuObjectPosition()
    {
        _mainMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        _loadingScreenObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    private void ShowMenu(Menu menu)
    {
        _mainMenuObject.SetActive(false);
        _loadingScreenObject.SetActive(false);

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
        }
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
        
        StartLoadedLevel();
    }

    private void StartLoadedLevel()
    {
        ShowMenu(Menu.LOADING_SCREEN);

        int loadedSceneIndex = SaveSystem.LoadGameData().currentSceneIndex;
        
        _asyncSceneHandler.LoadAsyncScene(loadedSceneIndex);
    }

    private void OnClick_Quit()
    {
        Debug.Log("Quit!");

        Application.Quit();
    }
}