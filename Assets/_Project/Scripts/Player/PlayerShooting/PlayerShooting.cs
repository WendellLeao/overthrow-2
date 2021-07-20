using UnityEngine;

[RequireComponent(typeof(PlayerInputListener))]
public sealed class PlayerShooting : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private float _fireRate;

    [Header("Ammo")]
    [SerializeField] private int _maxProjectileAmount;

    [Header("Player Transform")]
    [SerializeField] private Transform _playerTransform;

    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvents;
    [SerializeField] private GlobalGameEvents _globalGameEvents;

    private PlayerAmmo _playerAmmo;

    private float _nextFire;

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
        InitializePlayerAmmo();
    }

    private void SubscribeEvents()
    {
        _globalGameEvents.OnGameStateChanged += OnGameStateChanged_CheckIfCanShoot;
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnGameStateChanged -= OnGameStateChanged_CheckIfCanShoot;
        
        _localGameEvents.OnReadPlayerInputs -= OnPlayerShot_PerformShoot;
        _localGameEvents.OnPlayerShotBomb -= OnPlayerBombShot_PerformBombShooting;
    }

    private void InitializePlayerAmmo()
    {
        _playerAmmo = new PlayerAmmo(_maxProjectileAmount);

        _localGameEvents.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount);
    }
    
    private void OnGameStateChanged_CheckIfCanShoot(GameState gameState)
    {
        if(gameState == GameState.PLAYING)
        {
            _localGameEvents.OnReadPlayerInputs += OnPlayerShot_PerformShoot;
            _localGameEvents.OnPlayerShotBomb += OnPlayerBombShot_PerformBombShooting;
        }
        else
        {
            _localGameEvents.OnReadPlayerInputs -= OnPlayerShot_PerformShoot;
            _localGameEvents.OnPlayerShotBomb -= OnPlayerBombShot_PerformBombShooting;
        }
    }

    private void OnPlayerShot_PerformShoot(PlayerInputData playerInputData)
    {
        if(CanShoot(playerInputData))
        {
            _nextFire = Time.time + _fireRate;

            SpawnProjectile(PoolType.BALL_PROJECTILE);

            SoundManager.instance.Play("PlayerShooting");

            HandleAmmo();
        }
    }

    private void OnPlayerBombShot_PerformBombShooting()
    {
        SoundManager.instance.Play("PlayerShooting");

        SpawnProjectile(PoolType.BOMB_PROJECTILE);
    }
    
    private void SpawnProjectile(PoolType poolType)
    {
        GameObject projectileClone = ObjectPool.instance.GetObjectFromPool(poolType);
        
        SetProjectileTransform(projectileClone.transform);

        projectileClone.GetComponent<Projectile>().SetProjectileForce(_spawnTransform);
    }

    private void SetProjectileTransform(Transform projectileTransform)
    {
        projectileTransform.parent = _playerTransform;

        projectileTransform.position = _spawnTransform.position;
        projectileTransform.rotation = Quaternion.identity;
    }

    private void HandleAmmo()
    {
        _playerAmmo.DecreaseAmmo();
        
        _localGameEvents.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount);
    }

    private bool CanShoot(PlayerInputData playerInputData)
    {
        return playerInputData.IsShooting && !playerInputData.IsShootingBomb 
        && _playerAmmo.GetCurrentProjectileAmount > 0 && Time.time > _nextFire;
    }
}
