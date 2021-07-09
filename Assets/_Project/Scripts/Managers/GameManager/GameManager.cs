using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;

    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableObject _gameStateScriptableObject;

    private void Start()
    {
        ResumeGame();

        SetGameState(GameState.PLAYING);

        SoundManager.instance.PlaySoundtrack();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetGameState(GameState newGameState)
    {
        _gameStateScriptableObject._currentGameState = newGameState;

        _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
    }
}