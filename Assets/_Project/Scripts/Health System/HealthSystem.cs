using System;

public sealed class HealthSystem
{
    private int _maxHealthAmount;
    private int _currentHealthAmount;

    public event Action OnHealthChanged;

    public int GetCurrentHealthAmount => _currentHealthAmount;
    public int GetMaxHealthAmount => _maxHealthAmount;

    public HealthSystem(int maxHealthSystem)
    {
        _maxHealthAmount = maxHealthSystem;
        _currentHealthAmount = _maxHealthAmount;
    }

    public void Damage(int damageAmount)
    {
        _currentHealthAmount -= damageAmount;

        if(_currentHealthAmount <= 0)
        {
            _currentHealthAmount = 0;
        }

        OnHealthChanged?.Invoke();
    }
}