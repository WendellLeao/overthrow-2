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
    [SerializeField] private LocalGameEvents _localGameEvent;
    
    [Header("Game State")]
    [SerializeField] private GameStateScriptableOject _currentGameState;

    private PlayerAmmo _playerAmmo;

    private PoolType _poolType;

    private float nextFire;

    public void SetPoolType(PoolType poolType)
    {
        _poolType = poolType;
    }

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
        _localGameEvent.OnReadPlayerInputs += OnPlayerShot_PerformShoot;
        _localGameEvent.OnPlayerBombShot += OnPlayerBombShot_PerformBombShooting;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs -= OnPlayerShot_PerformShoot;
        _localGameEvent.OnPlayerBombShot -= OnPlayerBombShot_PerformBombShooting;
    }

    private void InitializePlayerAmmo()
    {
        _playerAmmo = new PlayerAmmo(_maxProjectileAmount);

        _localGameEvent.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount);
    }

    private void OnPlayerShot_PerformShoot(PlayerInputData playerInputData)
    {
        if(CanShoot(playerInputData) && _currentGameState.CurrentGameState == GameState.PLAYING)
        {
            nextFire = Time.time + _fireRate;

            SpawnProjectile(PoolType.BALL_PROJECTILE);

            SoundManager.instance.Play("PlayerShooting");

            HandleAmmo();
        }
    }

    private void OnPlayerBombShot_PerformBombShooting()
    {
        if(_currentGameState.CurrentGameState == GameState.PLAYING)
        {
            SpawnProjectile(PoolType.BOMB_PROJECTILE);
        }
    }

    private void SpawnProjectile(PoolType poolType)
    {
        GameObject projectileClone = ObjectPool.instance.GetObjectFromPool(poolType);
        
        projectileClone.transform.parent = _playerTransform;

        projectileClone.transform.position = _spawnTransform.position;
        projectileClone.transform.rotation = Quaternion.identity;

        projectileClone.GetComponent<Projectile>().SetProjectileForce(_spawnTransform);
    }

    private void HandleAmmo()
    {
        _playerAmmo.DecreaseAmmo();
        
        _localGameEvent.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount);
    }

    private bool CanShoot(PlayerInputData playerInputData)
    {
        return playerInputData.IsShooting && !playerInputData.IsShootingBomb 
        && _playerAmmo.GetCurrentProjectileAmount > 0 && Time.time > nextFire;
    }
}