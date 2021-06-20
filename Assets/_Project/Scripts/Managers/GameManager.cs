using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private enum GameState {Playing, Lose, Win, Paused}
    private GameState _gameState;

    private void Awake()
    {
        #region Singleton
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        #endregion

        _gameState = GameState.Playing;
        
        Cursor.lockState = CursorLockMode.Locked;
    }
}
