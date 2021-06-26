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

    [Header("Listening on channels")]
    [SerializeField] private GameEvent _playerShootEvent;

    private PlayerAmmo _playerAmmo;

    private void OnEnable()
    {
        _playerShootEvent.OnEventRaised += OnPlayerShot_PerformShoot;
    }

    private void OnDisable()
    {
        _playerShootEvent.OnEventRaised -= OnPlayerShot_PerformShoot;
    }
    
    private void Start()
    {
        _playerAmmo = new PlayerAmmo(_projectileAmount, _projectileAmountUI);
    }

    private void OnPlayerShot_PerformShoot()
    {
        if(_playerAmmo.GetCurrentProjectileAmount > 0)
        {
            GameObject cloneProjectile = Instantiate(_projectilePrefab, _spawnPosition.position, _spawnPosition.rotation);
            
            cloneProjectile.GetComponent<Projectile>().Initialize(_spawnPosition);

            _playerAmmo.DecreaseAmmo();
        }
    }
}