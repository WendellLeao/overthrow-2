using UnityEngine;

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
    
    private float _pingPongValue = 0f;

    public void DamagePlayer(PlayerDamageHandler playerDamageHandler)
    {
        playerDamageHandler.DamagePlayer(_damageToPlayerAmount);
    }
    
    private void Update()
    {
        HandleMovement();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerDamageHandler>(out PlayerDamageHandler playerDamageHandler))
        {
            DamagePlayer(playerDamageHandler);
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
