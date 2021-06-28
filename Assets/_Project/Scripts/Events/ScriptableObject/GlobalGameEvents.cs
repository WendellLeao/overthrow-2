using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewGlobalGameEvents",  menuName = "Events/Global Game Events")]
public sealed class GlobalGameEvents : ScriptableObject
{
    public UnityAction OnGameStateChanged;
    public UnityAction OnLevelCompleted;
    public UnityAction OnPlayerDied;
    public UnityAction OnGamePaused;
}