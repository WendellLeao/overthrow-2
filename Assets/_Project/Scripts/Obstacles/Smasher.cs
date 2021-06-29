using UnityEngine;

public sealed class Smasher : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _minimumVerticalDistance, _maximumVerticalDistance, _smashSpeed;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float pingPong = Mathf.PingPong(Time.time * _smashSpeed, 1);
        float verticalposition = Mathf.Lerp(_minimumVerticalDistance, _maximumVerticalDistance, pingPong);

        transform.position = new Vector3(transform.position.x, verticalposition, transform.position.z);
    }
}