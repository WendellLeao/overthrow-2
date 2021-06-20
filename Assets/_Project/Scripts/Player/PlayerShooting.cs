using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public sealed class PlayerShooting : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePf;
    [SerializeField] private Transform _spawnProjectilePos;
    [SerializeField] private float _shootForce;

    [Header("Ammo")]
    [SerializeField] private int _projectileAmount;
    private int _currentProjectileAmount;

    private void Start()
    {
        _currentProjectileAmount = _projectileAmount;

        ShootingContainerUI.instance.ProjectileAmountUI.UpdateProjectileAmountUI(_currentProjectileAmount);

        _playerController.PlayerInput.CharacterControls.Shoot.performed += _ => OnPlayerShoot_PerformShoot();
    }

    private void OnPlayerShoot_PerformShoot()
    {
        if(_currentProjectileAmount > 0)
        {
            GameObject cloneProjectile = Instantiate(_projectilePf, _spawnProjectilePos.position, _spawnProjectilePos.localRotation);

            cloneProjectile.GetComponent<Rigidbody>().velocity = transform.forward * _shootForce;

            _currentProjectileAmount--;
        
            ShootingContainerUI.instance.ProjectileAmountUI.UpdateProjectileAmountUI(_currentProjectileAmount);
        }
    }
}
