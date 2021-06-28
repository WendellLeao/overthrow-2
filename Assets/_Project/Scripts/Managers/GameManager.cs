using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _gameOverPanelObject;
    [SerializeField] private GameObject _winPanelObject;

    [Header("Invoking events")]
    [SerializeField] private VoidEventChannel _gameStateChangeEvent;
    
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    public void LevelComplete()
    {
        StopGame();

        SetGameState(GameState.WIN);

        _winPanelObject.SetActive(true);
    }

    public void LoseGame()
    {
        StopGame();

        SetGameState(GameState.LOSE);

        _gameOverPanelObject.SetActive(true);
    }

    private void Awake()
    {
        _gameStateScriptableObject.CurrentGameState = GameState.PLAYING;

        ResumeGame();
    }
    
    private void StopGame()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetGameState(GameState newGameState)
    {
        _gameStateScriptableObject._currentGameState = newGameState;

        _gameStateChangeEvent.RaiseEvent();
    }
}