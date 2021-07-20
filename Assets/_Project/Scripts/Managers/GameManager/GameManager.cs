using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;

    private void Start()
    {
        ResumeGame();

        SoundManager.instance.PlaySoundtrack();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        
        SetGameState(GameState.PLAYING);
    }

    private void SetGameState(GameState newGameState)
    {
        _globalGameEvents.OnGameStateChanged?.Invoke(newGameState);
    }
}
