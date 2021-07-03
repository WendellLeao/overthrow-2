using UnityEngine;

public sealed class Smasher : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _minimumVerticalDistance, _maximumVerticalDistance, _smashSpeed;
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

        transform.position = new Vector3(transform.position.x, verticalposition, transform.position.z);
    }
}