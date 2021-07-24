using UnityEngine;

public sealed class WinGameHandler : MonoBehaviour
{
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
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnLevelCompleted -= OnLevelCompleted_LevelComplete;
    }

    private void OnLevelCompleted_LevelComplete()
    {
        StopGame();

        ChangeGameState(GameState.WIN);

        if(SceneHandler.NextSceneExists())
        {
            if (_canSaveGame)
            {
                HandleGameSaving();
            }
        }
    }

    private void StopGame()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
    }
    
    private void ChangeGameState(GameState newGameState)
    {
        _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
    }

    private void HandleGameSaving()
    {
        SaveSystem.GetLocalData().CurrentSceneIndex = SceneHandler.GetNextSceneIndex();
            
        SaveSystem.SaveGameData();

        _canSaveGame = false;
    }
}
