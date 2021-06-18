using UnityEngine;

public sealed class PlayerMouseLook : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    
    [SerializeField] private float _horizontalSensitivity, _verticalSensitivy;
    
    private float _horizontalClamp = 85f;
    private float _horizontalRotation = 0f;
    private float _horizontalMouse, _verticalMouse;

    private void Update()
    {
        HandleLook();
    }

    private void HandleLook()
    {
        transform.Rotate(Vector3.up, _horizontalMouse * Time.deltaTime);

        _horizontalRotation -= _verticalMouse;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -_horizontalClamp, _horizontalClamp);

        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = _horizontalRotation;

        _cameraTransform.eulerAngles = targetRotation;
    }

    public void SetMouseInput(Vector2 mouseInput)
    {
        _horizontalMouse = mouseInput.x * _horizontalSensitivity;
        _verticalMouse = mouseInput.y * _verticalSensitivy;
    }
}
