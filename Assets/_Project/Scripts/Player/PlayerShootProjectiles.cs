using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public sealed class PlayerShootProjectiles : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Projectile")]
    [SerializeField] private GameObject _projectilePf;
    [SerializeField] private Transform _spawnProjectilePos;
    [SerializeField] private float _shootForce;

    [Header("Others")]
    [SerializeField] private Camera _mainCamera;

    private void Start()
    {
        _playerController.PlayerInput.CharacterControls.Shoot.performed += _ => OnPlayerShoot_PerformShoot();
    }

    private void OnPlayerShoot_PerformShoot()
    {
        GameObject cloneProjectile = Instantiate(_projectilePf, transform.position, Quaternion.identity);

        cloneProjectile.GetComponent<Rigidbody>().velocity = transform.forward * _shootForce;
    }
}
