using _Project.Scripts.Events.ScriptableObject;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI.Player.PlayerShootingUI
{
    public sealed class PlayerAmmoUI : MonoBehaviour
    {
        [Header("Text")]
        [SerializeField] private TMP_Text _projectileAmountText;

        [Header("Game Events")]
        [SerializeField] private LocalGameEvents _localGameEvent;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
    
        private void SubscribeEvents()
        {
            _localGameEvent.OnAmmoChanged += OnPlayerShot_UpdateProjectileAmountUI;
        }

        private void UnsubscribeEvents()
        {
            _localGameEvent.OnAmmoChanged -= OnPlayerShot_UpdateProjectileAmountUI;
        }

        private void OnPlayerShot_UpdateProjectileAmountUI(int currentProjectileAmount)
        {
            _projectileAmountText.text = "Ammo: " + currentProjectileAmount.ToString();

            UpdateProjectileAmountColorUI(currentProjectileAmount);
        }

        private void UpdateProjectileAmountColorUI(int projectileAmount)
        {
            if(projectileAmount <= 0)
            {
                _projectileAmountText.color = Color.red;
            }
        }
    }
}
