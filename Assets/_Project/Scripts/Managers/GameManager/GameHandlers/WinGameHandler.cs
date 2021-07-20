using UnityEngine;
using UnityEngine.UI;

public sealed class WinGameHandler : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _winPanelObject;
    [SerializeField] private GameObject _endGamePanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _mainMenuButton;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;

    private bool _canSaveGame = true;

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
        _globalGameEvents.OnLevelCompleted += OnLevelCompleted_LevelComplete;

        _continueButton.onClick.AddListener(SceneHandler.LoadNextScene);
        _mainMenuButton.onClick.AddListener(SceneHandler.BackToMainMenu);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnLevelCompleted -= OnLevelCompleted_LevelComplete;

        _continueButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnLevelCompleted_LevelComplete()
    {
        StopGame();

        SetGameState(GameState.WIN);

        if(SceneHandler.NextSceneExists())
        {
            if (_canSaveGame)
            {
                HandleGameSaving();
            }

            _winPanelObject.SetActive(true);
        }
        else
        {
            _endGamePanelObject.SetActive(true);
        }
    }

    private void StopGame()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
    }

    private void HandleGameSaving()
    {
        SaveSystem.GetLocalData().CurrentSceneIndex = SceneHandler.GetNextSceneIndex();
            
        SaveSystem.SaveGameData();

        _canSaveGame = false;
    }
    
    private void SetGameState(GameState newGameState)
    {
        _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
    }
}
