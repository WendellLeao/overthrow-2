using _Project.Scripts.DeactivatableObjects;
using _Project.Scripts.Enums.Managers.SoundManager;
using _Project.Scripts.Enums.ObjectPool;
using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Managers.SoundManager;
using _Project.Scripts.Obstacles.Interfaces;
using _Project.Scripts.Player;
using _Project.Scripts.Projectiles.SuperClass;
using UnityEngine;

namespace _Project.Scripts.Projectiles
{
    public sealed class CubeProjectile : Projectile, IObstacle
    {
        [Header(("Obstacle"))]
        [SerializeField] private int _damageToPlayerAmount;

        [Header(("Deactivatable Object"))]
        [SerializeField] private DeactivatableObject _deactivatableObject;

        [Header(("Game Events"))]
        [SerializeField] private LocalGameEvents _localGameEvents;
    
        public void DamagePlayer(int damageAmount)
        {
            _localGameEvents.OnPlayerIsHitted?.Invoke(damageAmount);
        }

        protected override void OnCollisionEnter(Collision other)
        {
            // if (!other.gameObject.TryGetComponent<CubeProjectile>(out CubeProjectile cubeProjectile))
            // {
            //     PlayCollisionSound();
            // }
        }

        protected override void PlayCollisionSound()
        {
            SoundManager.instance.PlaySound3D(Sound.CUBES_COLLISION, transform.position);
        }

        protected override void LateUpdate()
        {
            //Empty
        }

        protected override void ReturnProjectileToPool()
        {
            ObjectPool.ObjectPool.instance.ReturnObjectToPool(PoolType.CUBE_PROJECTILE, this.gameObject);
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerDamageHandler>(out PlayerDamageHandler playerDamageHandler) && _deactivatableObject.IsActivated)
            {
                _deactivatableObject.IsActivated = false;
                
                DamagePlayer(_damageToPlayerAmount);
            }
        }
    }
}
