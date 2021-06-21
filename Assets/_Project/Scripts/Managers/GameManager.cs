using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState _gameState;

    private void Awake()
    {
        _gameState = GameState.PLAYING;
        
        Cursor.lockState = CursorLockMode.Locked;
    }
}
