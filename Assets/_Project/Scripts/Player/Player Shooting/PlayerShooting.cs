using UnityEngine;

[RequireComponent(typeof(PlayerInputListener))]
public sealed class PlayerShooting : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPosition;

    [Header("Ammo")]
    [SerializeField] private int _projectileAmount;
    private PlayerAmmo _playerAmmo;

    public void OnPlayerShoot_PerformShoot()
    {
        if(_playerAmmo.GetCurrentProjectileAmount > 0)
        {
            GameObject cloneProjectile = Instantiate(_projectilePrefab, _spawnPosition.position, Quaternion.identity);//_spawnPosition.localRotation
            
            cloneProjectile.GetComponent<Projectile>().Initialize(this.transform);
            
            _playerAmmo.DecreaseAmmo();
        }
    }

    private void Start()
    {
        _playerAmmo = new PlayerAmmo(_projectileAmount);
    }
}
