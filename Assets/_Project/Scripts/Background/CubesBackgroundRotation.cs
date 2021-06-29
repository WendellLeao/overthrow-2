using UnityEngine;

public sealed class CubesBackgroundRotation : MonoBehaviour
{
    [SerializeField] private float _horizontalRotationSpeed, _verticalRotationSpeed, _depthRotationSpeed;

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        transform.Rotate(new Vector3(_horizontalRotationSpeed, _verticalRotationSpeed, _depthRotationSpeed));
    }
}