using UnityEngine;

[CreateAssetMenu(fileName = "NewGameState", menuName = "Game State")]
public sealed class GameStateScriptableOject : ScriptableObject
{
    public GameState _currentGameState;

    public GameState CurrentGameState
    {
        get{return _currentGameState;}
        set{_currentGameState = value;}
    }
}