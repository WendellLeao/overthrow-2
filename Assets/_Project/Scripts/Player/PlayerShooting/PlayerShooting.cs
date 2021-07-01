using UnityEngine;

[RequireComponent(typeof(PlayerInputListener))]
public sealed class PlayerShooting : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private float _fireRate;

    [Header("Ammo")]
    [SerializeField] private int _maxProjectileAmount;

    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;
    
    [Header("Game State")]
    [SerializeField] private GameStateScriptableOject _currentGameState;

    private PlayerAmmo _playerAmmo;

    private float nextFire;

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
        
        ClearObjectPolling();
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
        _playerAmmo = new PlayerAmmo(_maxProjectileAmount);

        _localGameEvent.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount);
    }

    private void ClearObjectPolling()
    {
        _objectPool.ClearPool();
    }

    private void OnPlayerShot_PerformShoot(PlayerInputData playerInputData)
    {
        if(CanShoot(playerInputData) && _currentGameState.CurrentGameState == GameState.PLAYING)
        {
            nextFire = Time.time + _fireRate;

            SpawnProjectile();

            HandleAmmo();
        }
    }

    private void SpawnProjectile()
    {
        GameObject newProjectile = _objectPool.GetObject(_projectilePrefab);
        
        newProjectile.transform.position = _spawnPosition.position;

        newProjectile.GetComponent<Projectile>().SetProjectileVelocity(_spawnPosition);
    }

    private void HandleAmmo()
    {
        _playerAmmo.DecreaseAmmo();
        
        _localGameEvent.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount);
    }

    private bool CanShoot(PlayerInputData playerInputData)
    {
        return playerInputData.IsShooting && Time.time > nextFire && _playerAmmo.GetCurrentProjectileAmount > 0;
    }
}