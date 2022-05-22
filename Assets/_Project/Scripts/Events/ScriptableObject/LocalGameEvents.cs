using _Project.Scripts.Player.PlayerInput;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Events.ScriptableObject
{
    [CreateAssetMenu(fileName = "NewLocalGameEvents",  menuName = "Events/Local Game Events")]
    public sealed class LocalGameEvents : UnityEngine.ScriptableObject
    {
        public UnityAction<int, int> OnHealthChanged;

        public UnityAction<int> OnPlayerIsHitted;
    
        public UnityAction<int, int> OnPowerChanged;
        
        public UnityAction OnShootButtonClick;

        public UnityAction OnPlayerShotBomb;

        public UnityAction OnLaserCollide;

        public delegate void DelegateOnReadPlayerInputs(PlayerInputData playerInputData);
        public DelegateOnReadPlayerInputs OnReadPlayerInputs;

        public delegate void DelegateOnAmmoChanged(int currentProjectileAmount);
        public DelegateOnAmmoChanged OnAmmoChanged;
    }
}
