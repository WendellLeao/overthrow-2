using UnityEngine;

public sealed class PauseGameHandler : MonoBehaviour
{
    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    [Header("Invoking events")]
    [SerializeField] private VoidEventChannel _gameStateChangeEvent;

    [Header("UI")]
    [SerializeField] private GameObject _pausePanelObject;
    
    public void HandlePauseGame()
    {
        if(CanPauseGame())
        {
            if (IsPaused())
            {
                HidePausePanel();
            }
            else
            {
                ShowPausePanel();
            }
        }
    }

    public void HidePausePanel()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        SetGameState(GameState.PLAYING);

        _pausePanelObject.SetActive(false);
    }

    private void ShowPausePanel()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;

        SetGameState(GameState.PAUSED);
        
        _pausePanelObject.SetActive(true);
    }

    private void SetGameState(GameState newGameState)
    {
        _gameStateScriptableObject._currentGameState = newGameState;

        _gameStateChangeEvent.RaiseEvent();
    }

    private bool IsPaused()
    {
        return Time.timeScale == 0f;
    }

    private bool CanPauseGame()
    {
        return _gameStateScriptableObject.CurrentGameState == GameState.PLAYING 
        || _gameStateScriptableObject.CurrentGameState == GameState.PAUSED;
    }
}