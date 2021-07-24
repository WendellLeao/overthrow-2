using UnityEngine;

public sealed class GameOverHandler : MonoBehaviour
{
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
        _globalGameEvents.OnPlayerDied += OnPlayerDied_LoseGame;
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnPlayerDied -= OnPlayerDied_LoseGame;
    }

    private void OnPlayerDied_LoseGame()
    {
        StopGame();

        ChangeGameState(GameState.LOSE);
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
}
