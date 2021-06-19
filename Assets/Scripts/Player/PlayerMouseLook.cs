using UnityEngine;

public sealed class PlayerMouseLook : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    
    [SerializeField] private float _horizontalSensitivity, _verticalSensitivy;
    
    private float _verticalRotation = 0f;
    private float _horizontalMouse, _verticalMouse;

    private void Update()
    {
        HandleVerticalLook();
        HandleHorizontalLook();

        Debug.Log(_verticalMouse);
    }

    public void SetMouseInput(Vector2 mouseInput)
    {
        _horizontalMouse = mouseInput.x * _horizontalSensitivity * Time.deltaTime;
        _verticalMouse = mouseInput.y * _verticalSensitivy * Time.deltaTime;
    }

    private void HandleVerticalLook()
    {
        _verticalRotation -= _verticalMouse;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }
    
    private void HandleHorizontalLook()
    {
        transform.Rotate(Vector3.up, _horizontalMouse);
    }
}