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
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    private SceneHandler _sceneHandler = new SceneHandler();

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

        // SaveSystem.SetCurrentLevelIndex(_sceneHandler.GetCurrentSceneIndex());
        // SaveSystem.SaveGame();

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

        _globalGameEvents.OnGameStateChanged?.Invoke();
    }
}