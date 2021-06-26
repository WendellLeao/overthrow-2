using UnityEngine;

[CreateAssetMenu(fileName = "NewHealthSystem", menuName = "HealthSystem/New Health System")]
public sealed class HealthSystem : ScriptableObject
{
    [Header("Variable")]
    [SerializeField] private int _maxHealthAmount;

    [Header("Invoking events")]
    [SerializeField] private VoidEventChannel _healthChangeEvent;

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

        _healthChangeEvent.RaiseEvent();
    }

    public void ResetCurrentHealthAmount()
    {
        _currentHealthAmount = _maxHealthAmount;
    }

    private void OnEnable()
    {
        _currentHealthAmount = _maxHealthAmount;
    }
}