using _Project.Scripts.Enums.Managers.GameManager;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Events.ScriptableObject
{
    [CreateAssetMenu(fileName = "NewGlobalGameEvents",  menuName = "Events/Global Game Events")]
    public sealed class GlobalGameEvents : UnityEngine.ScriptableObject
    {
        public UnityAction<GameState> OnGameStateChanged;

        public UnityAction<bool> OnGameIsPaused;
    
        public UnityAction OnLevelCompleted;
    
        public UnityAction OnPlayerDied;
    }
}
