using _Project.Scripts.Enums.Managers.GameManager;
using _Project.Scripts.Enums.Managers.SoundManager;
using _Project.Scripts.Enums.ObjectPool;
using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Managers.SoundManager;
using _Project.Scripts.Player.PlayerInput;
using _Project.Scripts.Projectiles.SuperClass;
using UnityEngine;

namespace _Project.Scripts.Player.PlayerShooting
{
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

        private PlayerInputData _playerInputData;

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
        
            _localGameEvents.OnShootButtonClick -= OnPlayerShot_PerformShoot;
            _localGameEvents.OnReadPlayerInputs -= OnPlayerShot_PerformShoot;
            _localGameEvents.OnPlayerShotBomb -= OnPlayerBombShot_PerformBombShooting;
        }

        private void InitializePlayerAmmo()
        {
            _playerAmmo = new PlayerAmmo(_maxProjectileAmount);

            _localGameEvents.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount());
        }
    
        private void OnGameStateChanged_CheckIfCanShoot(GameState gameState)
        {
            if(gameState == GameState.PLAYING)
            {
                _localGameEvents.OnShootButtonClick += OnPlayerShot_PerformShoot;
                _localGameEvents.OnReadPlayerInputs += OnPlayerShot_PerformShoot;
                _localGameEvents.OnPlayerShotBomb += OnPlayerBombShot_PerformBombShooting;
            }
            else
            {
                _localGameEvents.OnShootButtonClick -= OnPlayerShot_PerformShoot;
                _localGameEvents.OnReadPlayerInputs -= OnPlayerShot_PerformShoot;
                _localGameEvents.OnPlayerShotBomb -= OnPlayerBombShot_PerformBombShooting;
            }
        }

        private void OnPlayerShot_PerformShoot(PlayerInputData playerInputData)
        {
            _playerInputData = playerInputData;
        
            if(CanShoot(_playerInputData))
            {
                _nextFire = Time.time + _fireRate;

                SpawnProjectile(PoolType.BALL_PROJECTILE);

                SoundManager.instance.PlaySound3D(Sound.PLAYER_SHOOTING, transform.position);

                HandleAmmo();
            }
        }

        private void OnPlayerBombShot_PerformBombShooting()
        {
            SoundManager.instance.PlaySound3D(Sound.PLAYER_SHOOTING, transform.position);

            SpawnProjectile(PoolType.BOMB_PROJECTILE);
        }
    
        private void SpawnProjectile(PoolType poolType)
        {
            GameObject projectileClone = ObjectPool.ObjectPool.instance.GetObjectFromPool(poolType);
        
            SetProjectileTransform(projectileClone.transform);

            projectileClone.GetComponent<Projectile>().SetProjectileForce(_spawnTransform);
        }
    
        private void HandleAmmo()
        {
            _playerAmmo.DecreaseAmmo();
        
            _localGameEvents.OnAmmoChanged?.Invoke(_playerAmmo.GetCurrentProjectileAmount());
        }

        private bool CanShoot(PlayerInputData playerInputData)
        {
            return playerInputData.IsShooting && !playerInputData.IsShootingBomb 
                                              && _playerAmmo.GetCurrentProjectileAmount() > 0 && Time.time > _nextFire;
        }
    
        private void SetProjectileTransform(Transform projectileTransform)
        {
            projectileTransform.parent = _playerTransform;

            projectileTransform.position = _spawnTransform.position;
            projectileTransform.rotation = Quaternion.identity;
        }
    }
}
