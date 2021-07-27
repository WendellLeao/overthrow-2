using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    [Header("Health System")]
    [SerializeField] private HealthSystem _playerHealthSystem;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;
    [SerializeField] private LocalGameEvents _localGameEvents;

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
        _localGameEvents.OnPlayerIsHitted += OnPlayerIsHitted_DamagePlayer;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvents.OnPlayerIsHitted -= OnPlayerIsHitted_DamagePlayer;
    }

    private void Start()
    {
        ResetCurrentHealthAmount();
    }
    
    private void OnPlayerIsHitted_DamagePlayer(int damageAmount)
    {
        _playerHealthSystem.Damage(damageAmount);
        
        if(_playerHealthSystem.GetCurrentHealthAmount() > 0)
        {
            SoundManager.instance.PlaySound2D(Sound.PLAYER_DAMAGE);
        }
        
        CheckIfPlayerIsDead(_playerHealthSystem.GetCurrentHealthAmount());
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
