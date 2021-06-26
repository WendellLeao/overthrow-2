using UnityEngine;

[CreateAssetMenu(fileName = "NewHealthSystem", menuName = "HealthSystem/New Health System")]
public sealed class HealthSystem : ScriptableObject
{
    [Header("Variable")]
    [SerializeField] private int _maxHealthAmount;

    [Header("Invoking events")]
    [SerializeField] private GameEvent _healthChangeEvent;

    private int _currentHealthAmount;

    public int GetMaxHealthAmount => _maxHealthAmount;
    public int GetCurrentHealthAmount => _currentHealthAmount;

    public void Damage(int damageAmount)
    {
        _currentHealthAmount -= damageAmount;

        if(_currentHealthAmount <= 0)
        {
            _currentHealthAmount = 0;
        }

        _healthChangeEvent.OnEventRaised?.Invoke();
    }

    public void ResetCurrentHealthAmount()
    {
        _currentHealthAmount = _maxHealthAmount;
    }
}