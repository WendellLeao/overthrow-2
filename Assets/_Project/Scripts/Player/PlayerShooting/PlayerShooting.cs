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

    [Header("Game State")]
    [SerializeField] private GameStateScriptableOject _currentGameState;

    private PlayerAmmo _playerAmmo;

    public void PerformShoot()
    {
        if(_playerAmmo.GetCurrentProjectileAmount > 0 && _currentGameState.CurrentGameState == GameState.PLAYING)
        {
            GameObject cloneProjectile = Instantiate(_projectilePrefab, _spawnPosition.position, _spawnPosition.rotation);
            
            cloneProjectile.GetComponent<Projectile>().Initialize(_spawnPosition);

            _playerAmmo.DecreaseAmmo();
        }
    }
    
    private void Start()
    {
        _playerAmmo = new PlayerAmmo(_projectileAmount, _projectileAmountUI);
    }
}