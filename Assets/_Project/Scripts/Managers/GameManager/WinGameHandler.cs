using UnityEngine;
using UnityEngine.UI;

public sealed class WinGameHandler : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _winPanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _continueButton;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;

    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableObject _gameStateScriptableObject;

    private SceneHandler _sceneHandler = new SceneHandler();

    private bool canSaveGame = true;

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

        _continueButton.onClick.AddListener(_sceneHandler.LoadNextScene);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnLevelCompleted -= OnLevelCompleted_LevelComplete;

        _continueButton.onClick.RemoveAllListeners();
    }

    private void OnLevelCompleted_LevelComplete()
    {
        StopGame();

        SaveGame();

        SetGameState(GameState.WIN);

        _winPanelObject.SetActive(true);
    }

    private void StopGame()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
    }

    private void SetGameState(GameState newGameState)
    {
        _gameStateScriptableObject._currentGameState = newGameState;

        _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
    }

    private void SaveGame()
    {
        if(canSaveGame)
        {
            GameData.Instance.currentLevelIndex++;
            
            SaveSystem.SaveGameData();

            canSaveGame = false;
        }
    }
}