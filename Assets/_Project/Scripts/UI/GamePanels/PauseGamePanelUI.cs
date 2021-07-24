using UnityEngine.UI;
using UnityEngine;

public class PauseGamePanelUI : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _pausePanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _resumeGameButton; 
    [SerializeField] private Button _restartGameButton; 
    [SerializeField] private Button _mainMenuButton; 

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _globalGameEvents.OnGameIsPaused += OnGameIsPaused_HandlePauseGamePanelUI;

        _resumeGameButton.onClick.AddListener(delegate { _globalGameEvents.OnGameIsPaused?.Invoke(false); });
        
        _restartGameButton.onClick.AddListener(SceneHandler.ReloadScene);
        _mainMenuButton.onClick.AddListener(SceneHandler.BackToMainMenu);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnGameIsPaused -= OnGameIsPaused_HandlePauseGamePanelUI;

        _resumeGameButton.onClick.RemoveAllListeners();
        _restartGameButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnGameIsPaused_HandlePauseGamePanelUI(bool canPauseGame)
    {
        if (canPauseGame)
        {
            ShowPausePanel();
        }
        else
        {
            HidePausePanel();
        }
    }

    private void HidePausePanel()
    {
        _pausePanelObject.SetActive(false);
    }

    private void ShowPausePanel()
    {
        _pausePanelObject.SetActive(true);
    }
}
