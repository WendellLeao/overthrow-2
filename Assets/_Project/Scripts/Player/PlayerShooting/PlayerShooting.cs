using UnityEngine;

public sealed class PlayerShooting : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPosition;

    [Header("UI")]
    [SerializeField] private ProjectileAmountUI _projectileAmountUI;

    [Header("Ammo")]
    [SerializeField] private int _projectileAmount;

    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;
    
    [Header("Game State")]
    [SerializeField] private GameStateScriptableOject _currentGameState;

    private PlayerAmmo _playerAmmo;

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
        InstancePlayerAmmo();
    }

    private void SubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs += OnPlayerShot_PerformShoot;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs -= OnPlayerShot_PerformShoot;
    }

    private void InstancePlayerAmmo()
    {
        _playerAmmo = new PlayerAmmo(_projectileAmount, _projectileAmountUI);///Pass parameters by delegate
    }

    private void OnPlayerShot_PerformShoot(PlayerInputData playerInputData)
    {
        if(playerInputData.IsShooting && _playerAmmo.GetCurrentProjectileAmount > 0 && _currentGameState.CurrentGameState == GameState.PLAYING)
        {
            GameObject cloneProjectile = Instantiate(_projectilePrefab, _spawnPosition.position, _spawnPosition.rotation);
            
            cloneProjectile.GetComponent<Projectile>().Initialize(_spawnPosition);

            _playerAmmo.DecreaseAmmo();

            playerInputData.IsShooting = false;
        }
    }
}