using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Player.PlayerInput;
using UnityEngine.UI;
using UnityEngine;

namespace _Project.Scripts.Player.PlayerShooting
{
    public sealed class ShootButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private LocalGameEvents _localGameEvents;
    
        private PlayerInputData _playerInputData;

        private void Awake()
        {
            _button.onClick.AddListener(HandleShootButtonClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(HandleShootButtonClick);
        }

        private void HandleShootButtonClick()
        {
            _localGameEvents.OnShootButtonClick.Invoke();
        }
    }
}
