using UnityEngine;

public sealed class PlayerDamageHandler : MonoBehaviour
{
    
    /// <summary>
    /// DamageHandler não lida com o dano, mas sim o PlayerCollider aplica o dano...
    /// Acho que tu pecou aqui na "organização" da logica, pensa só...
    /// o PlayerCollider deveria Chamar um metodo, no PlayerDamageHandler (ou invocar um evento ? ) que esse script aqui sim APLIQUE o dano no player...
    ///
    /// Avaliando mais um pouco admito que achei essa logica um pouco confusa...
    /// o PlayerCollider aplica o dano no Health controller
    /// este então invoka um evento
    /// que  o PlayerDamageHandler escuta ....
    ///
    /// Por que isto tudo aqui não é feito no proprio HealthController ?
    /// admito que não entendi muito bem a razão por trás desse script do PlayerDamageHandler.
    /// Acho BOM vc tentar separar, mas, sera que era preciso ? sera que só não deixou o codigo meio  confuso ?  (ao menos em um primeiro momento é a minha visão)
    /// </summary>
    
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

    private void Start()
    {
        ResetCurrentHealthAmount();
    }

    private void SubscribeEvents()
    {
        _localGameEvents.OnHealthChanged += OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvents.OnHealthChanged -= OnHealthChanged_CheckIfPlayerIsDead;
    }

    private void ResetCurrentHealthAmount()
    {
        _playerHealthSystem.ResetCurrentHealthAmount();
    }

    private void OnHealthChanged_CheckIfPlayerIsDead(int currentHealthAmount, int maxHealthAmount)
    {
        if(currentHealthAmount <= 0)
        {
            _globalGameEvents.OnPlayerDied?.Invoke();
        }
    }
}