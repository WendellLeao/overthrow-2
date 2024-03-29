using _Project.Scripts.Events.ScriptableObject;
using UnityEngine;

namespace _Project.Scripts.HealthSystem
{
    [CreateAssetMenu(fileName = "NewHealthSystem", menuName = "HealthSystem/New Health System")]
    public sealed class HealthSystem : ScriptableObject
    {
        [Header("Variable")]
        [SerializeField] private int _maxHealthAmount;

        [Header("Game Events")]
        [SerializeField] private LocalGameEvents _localGameEvent;

        private int _currentHealthAmount;

        public void Damage(int damageAmount)
        {
            _currentHealthAmount -= damageAmount;

            if(_currentHealthAmount <= 0)
            {
                _currentHealthAmount = 0;
            }

            _localGameEvent.OnHealthChanged?.Invoke(_currentHealthAmount, _maxHealthAmount);
        }

        public void ResetCurrentHealthAmount()
        {
            _currentHealthAmount = _maxHealthAmount;
        }

        private void OnEnable()
        {
            _currentHealthAmount = _maxHealthAmount;
        }

        public int GetCurrentHealthAmount()
        {
            return _currentHealthAmount;
        }
    }
}
