using UnityEngine;

public sealed class Smasher : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _minimumVerticalDistance;
    [SerializeField] private float _maximumVerticalDistance; 
    [SerializeField] private float _smashSpeed;

    [Header("Smasher Components")]
    [SerializeField] private Transform _smaherTransform;
    
    private float _pingPongValue = 0f;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _pingPongValue += Time.deltaTime * _smashSpeed;

        float pingPong = Mathf.PingPong(_pingPongValue, 1);
        float verticalposition = Mathf.Lerp(_minimumVerticalDistance, _maximumVerticalDistance, pingPong);

        _smaherTransform.position = new Vector3(transform.position.x, verticalposition, _smaherTransform.position.z);
    }
}
