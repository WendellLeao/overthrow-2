using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    
    private GameState _currentGameState;

    private void Awake()
    {
        _currentGameState = GameState.PLAYING;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        _playerController.GetWayPointSystem.OnPlayerIsAtLastTarget += OnPlayerIsAtLastTarget_LevelComplete;
        _playerController.GetPlayerDamageHandler.OnPlayerDied += OnPlayerDied_LoseGame;
    }

    private void OnDisable()
    {
        _playerController.GetWayPointSystem.OnPlayerIsAtLastTarget -= OnPlayerIsAtLastTarget_LevelComplete;
        _playerController.GetPlayerDamageHandler.OnPlayerDied -= OnPlayerDied_LoseGame;
    }

    void Update()
    {
        Debug.Log(_currentGameState);
    }

    private void OnPlayerIsAtLastTarget_LevelComplete()
    {
        SetGameState(GameState.WIN);

        CanvasAssets.instance.GetWinPanelObject.SetActive(true);
    }

    private void OnPlayerDied_LoseGame()
    {
        SetGameState(GameState.LOSE);

        CanvasAssets.instance.GetGameOverPanelObject.SetActive(true);
    }

    private void SetGameState(GameState newGameState)
    {
        Time.timeScale = 0f;

        _currentGameState = newGameState;

        Cursor.lockState = CursorLockMode.None;
    }
}
