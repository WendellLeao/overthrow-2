using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewGameEvents",  menuName = "Events/Game Events")]
public sealed class GameEvents : ScriptableObject
{
    //Player Events
    public UnityAction OnHealthChanged;
    public UnityAction OnPlayerDied;
    public UnityAction OnPlayerShot;

    //Game Events
    public UnityAction OnGameStateChanged;
    public UnityAction OnLevelCompleted;
    public UnityAction OnGamePaused;
}