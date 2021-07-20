using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewGlobalGameEvents",  menuName = "Events/Global Game Events")]
public sealed class GlobalGameEvents : ScriptableObject
{
    public UnityAction<GameState> OnGameStateChanged;
    public UnityAction OnLevelCompleted;
    public UnityAction OnPlayerDied;
}
