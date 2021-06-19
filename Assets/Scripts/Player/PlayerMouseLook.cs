using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public sealed class PlayerMouseLook : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Mouse Look")]
    [SerializeField] private Transform _cameraTransform;///////////////////////
    
    [SerializeField] private float _horizontalSensitivity, _verticalSensitivy;
    
    private float _verticalRotation = 0f;
    private float _horizontalMouse, _verticalMouse;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;/////////////////////////
    }

    private void Update()
    {
        SetMouseInput(_playerController.PlayerInput.GetMouseDelta());

        HandleVerticalLook();
        HandleHorizontalLook();
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
        
        _cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }
    
    private void HandleHorizontalLook()
    {
        transform.Rotate(Vector3.up, _horizontalMouse);
    }
}