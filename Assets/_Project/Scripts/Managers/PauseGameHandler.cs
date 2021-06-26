using UnityEngine;

public sealed class PauseGameHandler : MonoBehaviour
{
    [Header("Listening on channels")]
    [SerializeField] private GameEvent _pauseGameEvent;

    [Header("UI")]
    [SerializeField] private GameObject _pausePanelObject;
    
    public void HidePausePanel()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;

        _pausePanelObject.SetActive(false);
    }

    private void OnEnable()
    {
        _pauseGameEvent.OnEventRaised += OnGamePaused_HandlePauseGame;
    }

    private void OnDisable()
    {
        _pauseGameEvent.OnEventRaised -= OnGamePaused_HandlePauseGame;
    }

    private void OnGamePaused_HandlePauseGame()
    {
        if(IsPaused())
        {
            HidePausePanel();
        }
        else
        {
            ShowPausePanel();
        }
    }

    private void ShowPausePanel()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        
        _pausePanelObject.SetActive(true);
    }

    private bool IsPaused()
    {
        return Time.timeScale == 0f;
    }
}