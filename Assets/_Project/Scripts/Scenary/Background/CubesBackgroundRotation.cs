using UnityEngine;

public sealed class CubesBackgroundRotation : MonoBehaviour
{
    [SerializeField] private Transform _cubeTransform;
    [SerializeField] private float _xRotationSpeed, _yRotationSpeed, _zRotationSpeed;

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        _cubeTransform.Rotate(new Vector3(_xRotationSpeed, _yRotationSpeed, _zRotationSpeed) * Time.deltaTime);
    }
}
