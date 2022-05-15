using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Player.PlayerInput;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Player.PlayerShooting
{
    public sealed class ShootButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private LocalGameEvents _localGameEvents;
    
        private PlayerInputData _playerInputData;

        private void Awake()
        {
            _localGameEvents.OnReadPlayerInputs += HandlePlayerInputs;
        
            _button.onClick.AddListener(HandleShootButtonClick);
        }

        private void OnDestroy()
        {
            _localGameEvents.OnReadPlayerInputs -= HandlePlayerInputs;
        
            _button.onClick.RemoveListener(HandleShootButtonClick);
        }
    
        private void HandlePlayerInputs(PlayerInputData playerInputData)
        {
            _playerInputData = playerInputData;
        }

        private void HandleShootButtonClick()
        {
            _localGameEvents.OnShootButtonClick.Invoke(_playerInputData);

            Debug.Log("HandleShootButtonClick");
        }
    }
}
