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

    private void Start()
    {
        _playerController.PlayerInput.CharacterControls.Shoot.performed += _ => OnPlayerShoot_PerformShoot();
    }

    private void OnPlayerShoot_PerformShoot()
    {
        GameObject cloneProjectile = Instantiate(_projectilePf, _spawnProjectilePos.position, _spawnProjectilePos.localRotation);

        cloneProjectile.GetComponent<Rigidbody>().velocity = transform.forward * _shootForce;
    }
}
