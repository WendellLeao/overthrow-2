using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameState {Playing, Lose, Win, Paused}
    private GameState _gameState;

    private void Awake()
    {
        _gameState = GameState.Playing;
        
        Cursor.lockState = CursorLockMode.Locked;
    }
}
