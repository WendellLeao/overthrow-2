using UnityEngine;

[RequireComponent(typeof(PlayerInputListener))]
public sealed class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    
    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPosition;

    [Header("Ammo")]
    [SerializeField] private int _projectileAmount;
    private PlayerAmmo _playerAmmo;

    private void OnEnable()
    {
        _playerController.GetPlayerInput.OnPlayerShot += OnPlayerShot_PerformShoot;
    }

    private void OnDisable()
    {
        _playerController.GetPlayerInput.OnPlayerShot -= OnPlayerShot_PerformShoot;
    }
    
    private void Start()
    {
        _playerAmmo = new PlayerAmmo(_projectileAmount);
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