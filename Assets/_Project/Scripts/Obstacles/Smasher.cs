using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Obstacles.Interfaces;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts.Obstacles
{
    public sealed class Smasher : MonoBehaviour, IObstacle
    {
        [Header("Movement")]
        [SerializeField] private float _minimumVerticalDistance;
        [SerializeField] private float _maximumVerticalDistance; 
        [SerializeField] private float _smashSpeed;

        [Header("Smasher Components")]
        [SerializeField] private Transform _smaherTransform;

        [Header("Obstacle")]
        [SerializeField] private int _damageToPlayerAmount;
    
        [Header(("Game Events"))]
        [SerializeField] private LocalGameEvents _localGameEvents;
    
        private float _pingPongValue = 0f;

        public void DamagePlayer(int damageAmount)
        {
            _localGameEvents.OnPlayerIsHitted?.Invoke(damageAmount);
        }
    
        private void Update()
        {
            HandleMovement();
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerDamageHandler>(out PlayerDamageHandler playerDamageHandler))
            {
                DamagePlayer(_damageToPlayerAmount);
            }
        }
    
        private void HandleMovement()
        {
            _pingPongValue += Time.deltaTime * _smashSpeed;

            float pingPong = Mathf.PingPong(_pingPongValue, 1);
            float verticalposition = Mathf.Lerp(_minimumVerticalDistance, _maximumVerticalDistance, pingPong);

            _smaherTransform.position = new Vector3(transform.position.x, verticalposition, _smaherTransform.position.z);
        }
    }
}
