using UnityEngine;

[RequireComponent(typeof(PlayerInputListener))]
public sealed class PlayerMouseLook : MonoBehaviour
{
    [Header("Mouse Look")]
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _horizontalSensitivity, _verticalSensitivy;

    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;
    
    private float _verticalRotation = 0f;
    private float _horizontalMouse, _verticalMouse;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void Update()
    {
        HandleCameraVerticalRotation();
        HandlePlayerHorizontalRotation();
    }

    private void SubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs += SetMouseInput;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs -= SetMouseInput;
    }

    private void HandleCameraVerticalRotation()
    {
        _verticalRotation -= _verticalMouse;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90f, 90f);
        
        _cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }
    
    private void HandlePlayerHorizontalRotation()
    {
        this.transform.Rotate(Vector3.up, _horizontalMouse);
    }

    private void SetMouseInput(PlayerInputData playerInputData)
    {
        _horizontalMouse = playerInputData.MousePosition.x * _horizontalSensitivity * Time.deltaTime;
        _verticalMouse = playerInputData.MousePosition.y * _verticalSensitivy * Time.deltaTime;
    }
}