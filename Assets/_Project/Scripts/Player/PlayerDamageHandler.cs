using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    
    public void DamagePlayer(int damageAmount)
    {
        _playerHealthSystem.Damage(damageAmount);
        
        CheckIfPlayerIsDead(_playerHealthSystem.GetCurrentHealthAmount());
    }
    
    private void Start()
    {
        ResetCurrentHealthAmount();
    }

    private void CheckIfPlayerIsDead(int currentHealthAmount)
    {
        if(currentHealthAmount <= 0)
        {
            _globalGameEvents.OnPlayerDied?.Invoke();
        }
    }

    private void ResetCurrentHealthAmount()
    {
        _playerHealthSystem.ResetCurrentHealthAmount();
    }
}
