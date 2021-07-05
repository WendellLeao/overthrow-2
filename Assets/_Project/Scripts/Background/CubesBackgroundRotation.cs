using UnityEngine;

public sealed class CubesBackgroundRotation : MonoBehaviour
{
    [SerializeField] private float _xRotationSpeed, _yRotationSpeed, _zRotationSpeed;

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        transform.Rotate(new Vector3(_xRotationSpeed, _yRotationSpeed, _zRotationSpeed) * Time.deltaTime);
    }
}